import { Component, EventEmitter, Input, Output } from '@angular/core';
import { Seat } from 'src/app/shared/models/seat';

@Component({
  selector: 'app-seat',
  templateUrl: './seat.component.html',
  styleUrls: ['./seat.component.scss']
})
export class SeatComponent {

  @Output() selectedSeat = new EventEmitter<string>();
  @Input() seat!: Seat;

  onSeatClick(seatNumber: string) {
    this.selectedSeat.emit(seatNumber);
  }
}
