import { Component, OnInit } from '@angular/core';
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
  selectedSeats: string[] = [];
  selectedTime: string = '';
  noOfSeats=[1,2,3,4,5];
  selectedNoOfSeats:number=0;
  reservedSeats: ReservedSeat[] = []
  isBookTicketsVisible: boolean = false;
  movieId: number = 0;
  movieName: string = '';
  isNoOfSeatsVisible:boolean=false;
  theatreData: Theatre = {
    id: 0,
    name: '',
    rows: 0,
    columns: 0,
    movieIds: [],
    showTime: "",
    location: '',
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
      this.movieId = params['movieId'];
      this.movieName = params['movieName'];

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
    const rows = this.theatreData.rows;
    const columns = this.theatreData.columns;
    const request: ReservedSeat = {
      theatreId: this.theatreData.id,
      showTime: this.selectedTime,
      seatNumber: '',
      isReserved: false,
      isDisabled: false,
      movieId: this.movieId
    }
    for (let row = 1; row <= rows; row++) {
      const rowSeats: Seat[] = [];
      const rowName = String.fromCharCode(64 + row);
      for (let col = 1; col <= columns; col++) {
        const seatNumber = rowName + col;
        rowSeats.push({ seatNumber, isReserved: false, isDisabled: false });
      }
      this.rows.push(rowSeats);
    }
    this.apiService.reservedSeats(request).subscribe({
      next: (res) => {
        this.response = res
        this.response.data.forEach((element: { theatreId: number; seatNumber: string; }) => {
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

  reserveSeat(startingSeatNumber: string): void {
    const rowIndex = this.rows.findIndex(row => row.some(seat => seat.seatNumber === startingSeatNumber));

    if (rowIndex === -1) {
      console.error('Row not found.');
      return;
    }

    const startingSeatIndex = this.rows[rowIndex].findIndex(seat => seat.seatNumber === startingSeatNumber);

    for (let i = startingSeatIndex; i > startingSeatIndex - this.selectedNoOfSeats; i--) {
      const currentSeat = this.rows[rowIndex][i];

      if (!currentSeat) {
        console.error('Seat not found.');
        continue;
      }

      const seatIndex = this.selectedSeats.indexOf(currentSeat.seatNumber);
      if (seatIndex === -1) {
        if(this.selectedSeats.length<=this.selectedNoOfSeats){
        this.selectedSeats.push(currentSeat.seatNumber);
        }
        else{
          this.selectedSeats.shift();
          this.selectedSeats.push(currentSeat.seatNumber);
        }
      }
    }
  }

  onSelectTime(time: string) {
    this.selectedTime = time.toString();
    this.populateSeatData();
    this.isBookTicketsVisible = true;
    this.isNoOfSeatsVisible = true;
  }

  onNoOfSeatsClick(number:number){
    this.selectedNoOfSeats = number;
    console.log(this.selectedNoOfSeats);
  }

  bookMovie() {
    const bookingDetails: BookingDetails = {
      movieName: this.movieName,
      movieId: this.movieId,
      theatreName: this.theatreData.name,
      theatreId: this.theatreData.id,
      showTime: this.selectedTime,
      date: new Date(),
      seatNumbers: this.selectedSeats,
      totalAmount: this.theatreData.ticketPrice * this.selectedSeats.length,
    }
    if (bookingDetails.seatNumbers.length != 0) {
      const popUp = this.dialog.open(PopupComponent, {
        data: bookingDetails
      });
      popUp.afterClosed().subscribe(
        result => {
          if (result) {
            this.selectedSeats = [];
            this.populateSeatData();
          }
        })
      popUp.backdropClick().subscribe(
        result => {
          if (result) {
            this.selectedSeats = [];
            this.populateSeatData();
          }
        })
    }
    else {
      alert('Please select seats for booking')
    }
  }
}
