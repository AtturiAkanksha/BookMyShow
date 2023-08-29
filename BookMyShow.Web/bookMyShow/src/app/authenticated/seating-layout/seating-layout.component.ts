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
  isBookMovieVisible: boolean = false;
  isNoOfSeatsVisible: boolean = false;
  isSeatingVisible: boolean = false;
  isUserLogged: boolean = false;
  selectedNoOfSeats: number = 0;
  movieId: number = 0;
  movieName: string = '';
  selectedTime: string = '';
  noOfSeats = [1, 2, 3, 4, 5];
  timings: string[] = []
  rows: Seat[][] = [];
  selectedSeats: string[] = [];
  reservedSeats: ReservedSeat[] = []
  theatreData!: Theatre;
  response!: ResponseData;

  constructor(private dialog: MatDialog, private apiService: ApiService, private route: ActivatedRoute) { }

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

  reserveSeat(startingSeatNumber: string) {
    const rowIndex = this.rows.findIndex(row => row.some(seat => seat.seatNumber === startingSeatNumber));
    const startingSeatIndex = this.rows[rowIndex].findIndex(seat => seat.seatNumber === startingSeatNumber);
    if (this.selectedSeats.includes(startingSeatNumber)) {
      const deselectedSeat = this.rows.flat().find(seat => seat.seatNumber === startingSeatNumber);
      if (deselectedSeat) {
        deselectedSeat.isReserved = false;
        const index = this.selectedSeats.indexOf(startingSeatNumber);
        this.selectedSeats.splice(index, 1)
      }
    }
    else {
      for (let i = startingSeatIndex; i > startingSeatIndex - this.selectedNoOfSeats; i--) {
        const currentSeat = this.rows[rowIndex][i];
        const seatIndex = this.selectedSeats.indexOf(currentSeat.seatNumber);
        if (seatIndex === -1 && !currentSeat.isDisabled) {
          if (this.selectedSeats.length < this.selectedNoOfSeats) {
            this.selectedSeats.push(currentSeat.seatNumber);
          }
          else {
            const deselectedSeatNumber = this.selectedSeats.shift();
            const deselectedSeat = this.rows.flat().find(seat => seat.seatNumber === deselectedSeatNumber);
            if (deselectedSeat) {
              deselectedSeat.isReserved = false;
            }
            this.selectedSeats.push(currentSeat.seatNumber);
          }
          currentSeat.isReserved = true;
        }
      }
    }
  }

  onSelectTime(time: string) {
    this.selectedTime = time.toString();
    this.populateSeatData();
    this.isBookMovieVisible = true;
    this.isNoOfSeatsVisible = true;
  }

  onNoOfSeatsClick(number: number) {
    this.selectedNoOfSeats = number;
    this.isSeatingVisible = true;
  }

  bookMovie() {
    var user = JSON.parse(localStorage.getItem('user') || '{}')
    if (user.length) {
      this.isUserLogged = true;
    }
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
        data: { bookingDetails: bookingDetails, isUserLogged: this.isUserLogged }
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

