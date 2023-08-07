import { Component, EventEmitter, Input, Output } from '@angular/core';
import { Seat } from 'src/app/shared/models/seat';

@Component({
  selector: 'app-seat',
  templateUrl: './seat.component.html',
  styleUrls: ['./seat.component.scss']
})
export class SeatComponent {

  @Output() selectedSeat = new EventEmitter<number>();
  @Input() seat: Seat = {
    seatNumber: 0,
    isReserved: false,
    isDisabled: false
  }

  reserveSeat(seatNumber: number) {
    this.selectedSeat.emit(seatNumber);
  }
}
