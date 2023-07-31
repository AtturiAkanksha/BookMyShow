import { Component, OnInit, Renderer2 } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { Seat } from 'src/app/shared/models/seat';
import { Theatre } from 'src/app/shared/models/theatre';
import { DataService } from 'src/app/shared/services/data.service';
import { PopupComponent } from '../popup/popup.component';
import { BookingDetails } from 'src/app/shared/models/booking-details';
import { authService } from 'src/app/shared/services/auth.service';
import { ReservedSeat } from 'src/app/shared/models/reserved-seats';

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
  receivedData: Theatre = {
    id: 0,
    theatreName: '',
    theatreRows: 0,
    theatreColumns: 0,
    movieTimings: '',
    ticketPrice: 0
  };

  constructor(private dataService: DataService, private dialog: MatDialog,
    private authService: authService, private renderer: Renderer2) {
  }

  ngOnInit() {
    this.getData();
    this.populateSeatData();
  }

  getData() {
    this.receivedData = this.dataService.getData();
    this.timings = this.commaSeparatedStringToArray(this.receivedData.movieTimings);
  }

  commaSeparatedStringToArray(inputString: string): string[] {
    return inputString.split(',').map(item => item.trim());
  }

  populateSeatData() {
    const rows = this.receivedData.theatreColumns;
    const columns = this.receivedData.theatreRows;
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
          if (element.theatreId == this.receivedData.id) {
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
    this.selectedTime = time;
  }

  onClick() {
    const bookingDetails: BookingDetails = {
      movieName: JSON.parse(localStorage.getItem('movieName') ?? ""),
      theatreName: this.receivedData.theatreName,
      theatreId: this.receivedData.id,
      movieTimings: this.selectedTime,
      date: new Date(),
      seatNames: this.selectedSeats,
      totalAmount: this.receivedData.ticketPrice * this.selectedSeats.length,
      totalSeats: this.selectedSeats.length
    }
    this.dialog.open(PopupComponent, {
      data: bookingDetails,
    });
  }
}