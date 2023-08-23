import { Component, Inject } from '@angular/core';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';
import { ToastrService } from 'ngx-toastr';
import { BookingDetails } from 'src/app/shared/models/booking-details';
import { ApiService } from 'src/app/shared/services/api.service';

@Component({
  selector: 'app-popup',
  templateUrl: './popup.component.html',
  styleUrls: ['./popup.component.scss']
})

export class PopupComponent {

  bookingDetails = this.data;

  constructor(@Inject(MAT_DIALOG_DATA) public data: BookingDetails, private toastr: ToastrService, private apiService: ApiService) { }

  confirmBooking() {
    this.apiService.bookMovie(this.data).subscribe(
      {
        next:
          (res) => {
            if (res['isSuccess'] == true) {
              this.toastr.success(`yayyy! your tickets for ${this.bookingDetails.movieName} are booked`)
            }
            else {
              this.toastr.error("sorry your booking is not successful")
            }
          }
      }
    );
  }
}
