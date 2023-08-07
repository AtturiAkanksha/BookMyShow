import { Component, OnInit, Renderer2 } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { Seat } from 'src/app/shared/models/seat';
import { PopupComponent } from '../popup/popup.component';
import { BookingDetails } from 'src/app/shared/models/booking-details';
import { ApiService } from 'src/app/shared/services/api.service';
import { ReservedSeat } from 'src/app/shared/models/reserved-seat';
import { ActivatedRoute } from '@angular/router';
import { Theatre } from 'src/app/shared/models/theatre';
import { ResponseData } from 'src/app/shared/models/response-data';

@Component({
  selector: 'app-theatre',
  templateUrl: './seating-layout.component.html',
  styleUrls: ['./seating-layout.component.scss']
})

export class SeatingLayoutComponent implements OnInit {
  timings: string[] = []
  rows: Seat[][] = [];
  selectedSeats: number[] = [];
  selectedTime: string = '';
  reservedSeats: ReservedSeat[] = []
  isBookTicketsVisible: boolean = false;
  theatreData: Theatre = {
    id: 0,
    theatreName: '',
    theatreRows: 0,
    theatreColumns: 0,
    movieIds: [],
    movieTimings: "",
    locationName: '',
    ticketPrice: 0
  }
  response: ResponseData = {
    data: null,
    isSuccess: false,
    status: 200,
    error: ''
  }

  constructor(private dialog: MatDialog,
    private apiService: ApiService, private route: ActivatedRoute) {
  }

  ngOnInit() {
    this.route.params.subscribe(params => {
      const theatreId = params['id'];
      this.apiService.getTheatreById(theatreId).subscribe({
        next:
          (res) => {
            this.response = res
            this.theatreData = this.response.data
          }
      });
    });
  }

  populateSeatData() {
    this.rows = [];
    const rows = this.theatreData.theatreColumns;
    const columns = this.theatreData.theatreRows;
    const request: ReservedSeat = {
      theatreId: this.theatreData.id,
      movieTime: this.selectedTime,
      seatNumber: 0
    }
    let seatNumber = 1;
    for (let row = 1; row <= rows; row++) {
      const rowSeats: Seat[] = [];
      for (let col = 1; col <= columns; col++) {
        rowSeats.push({ seatNumber, isReserved: false, isDisabled: false });
        seatNumber++;
      }
      this.rows.push(rowSeats);
    }
    this.apiService.getReservedSeats(request).subscribe({
      next: (res) => {
        this.response = res
        this.response.data.forEach((element: { theatreId: number; seatNumber: number; }) => {
          if (element.theatreId == this.theatreData.id) {
            this.rows.flat().find(seat => {
              if (seat.seatNumber === element.seatNumber) {
                seat.isDisabled = true;
              }
            });
          }
        });
      }
    })
  }

  reserveSeat(seatNumber: number): void {
    const seatToReserve = this.rows.flat().find(seat => seat.seatNumber === seatNumber);
    const index = this.selectedSeats.indexOf(seatNumber);
    if (seatToReserve !== undefined) {
      if (!seatToReserve) {
        console.error('Seat not found.');
        return;
      }
      seatToReserve.isReserved = !seatToReserve.isReserved;
      if (index === -1) {
        this.selectedSeats.push(seatNumber);
      } else {
        if (seatToReserve.isReserved) {
          seatToReserve.isReserved = !seatToReserve.isReserved;
        }
        this.selectedSeats.splice(index, 1);
      }
    }
  }

  onSelectTime(time: string) {
    this.selectedTime = time.toString();
    this.populateSeatData();
    this.isBookTicketsVisible = true;
  }

  bookMovie() {
    const bookingDetails: BookingDetails = {
      movieName: JSON.parse(localStorage.getItem('movieName') ?? ""),
      movieId: JSON.parse(localStorage.getItem('movieId') ?? ""),
      theatreName: this.theatreData.theatreName,
      theatreId: this.theatreData.id,
      movieTimings: this.selectedTime,
      date: new Date(),
      seatNumbers: this.selectedSeats,
      totalAmount: this.theatreData.ticketPrice * this.selectedSeats.length,
      seatsCount: this.selectedSeats.length
    }
    this.dialog.open(PopupComponent, {
      data: bookingDetails,
    });
  }
}
