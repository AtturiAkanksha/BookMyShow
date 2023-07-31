import { Component, Inject } from '@angular/core';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';
import { BookingDetails } from 'src/app/shared/models/booking-details';
import { authService } from 'src/app/shared/services/auth.service';

@Component({
  selector: 'app-popup',
  templateUrl: './popup.component.html',
  styleUrls: ['./popup.component.scss']
})
export class PopupComponent {

  constructor(@Inject(MAT_DIALOG_DATA) public data: BookingDetails, private authService: authService) { }
  bookingDetails = this.data;
 
  onClickFunction() {
    this.authService.sendBookedDetails(this.data).subscribe(
      {
        next:
          (res) => {
            if(res){
              alert(`yayyy! your tickets for ${this.bookingDetails.movieName} are booked`)
            }
            else{
              alert("sorry your booking is not successful")
            }
          }
      }
    );
  }
}
