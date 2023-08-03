import { Component, OnInit, Renderer2 } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { Seat } from 'src/app/shared/models/seat';
import { Theatre } from 'src/app/shared/models/theatre';
import { PopupComponent } from '../popup/popup.component';
import { BookingDetails } from 'src/app/shared/models/booking-details';
import { authService } from 'src/app/shared/services/auth.service';
import { ReservedSeat } from 'src/app/shared/models/reserved-seat';
import { Time } from '@angular/common';

@Component({
  selector: 'app-theatre',
  templateUrl: './seating.component.html',
  styleUrls: ['./seating.component.scss']
})

export class SeatingComponent implements OnInit {
  timings: string[] = []
  rows: Seat[][] = [];
  selectedSeats: number[] = [];
  selectedTime: string = '';
  theatreData: Theatre = JSON.parse(localStorage.getItem('theatreData') ?? "")
  movieName: string = JSON.parse(localStorage.getItem('movieName') ?? "")

  constructor(private dialog: MatDialog,
    private authService: authService) {
  }

  ngOnInit() {
    this.populateSeatData();
  }

  populateSeatData() {
    const rows = this.theatreData.theatreColumns;
    const columns = this.theatreData.theatreRows;
    let seatNumber = 1;
    for (let row = 1; row <= rows; row++) {
      const rowSeats: Seat[] = [];
      for (let col = 1; col <= columns; col++) {
        rowSeats.push({ seatNumber, isReserved: false, isDisabled: false });
        seatNumber++;
      }
      this.rows.push(rowSeats);
    }
    this.authService.getReservedSeats().subscribe({
      next: (res: ReservedSeat[]) => {
        res.forEach(element => {
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

  onSelectTime(time: Time) {
    this.selectedTime = time.toString();
  }

  onClick() {
    const bookingDetails: BookingDetails = {
      movieName: JSON.parse(localStorage.getItem('movieName') ?? ""),
      movieId: JSON.parse(localStorage.getItem('movieId') ?? ""),
      theatreName: this.theatreData.theatreName,
      theatreId: this.theatreData.id,
      movieTimings: this.selectedTime,
      date: new Date(),
      seatNames: this.selectedSeats,
      totalAmount: this.theatreData.ticketPrice * this.selectedSeats.length,
      seatsCount: this.selectedSeats.length
    }
    this.dialog.open(PopupComponent, {
      data: bookingDetails,
    });
  }
}
