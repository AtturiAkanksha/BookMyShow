import { MicrosoftLoginProvider, SocialAuthService, SocialUser } from '@abacritt/angularx-social-login';
import { Component, Inject, OnInit } from '@angular/core';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';
import { ToastrService } from 'ngx-toastr';
import { AuthRequest } from 'src/app/shared/models/auth-request';
import { BookingDetails } from 'src/app/shared/models/booking-details';
import { ApiService } from 'src/app/shared/services/api.service';

@Component({
  selector: 'app-popup',
  templateUrl: './popup.component.html',
  styleUrls: ['./popup.component.scss']
})

export class PopupComponent implements OnInit {

  bookingDetails: BookingDetails = this.data.bookingDetails;
  isUserLogged: boolean = this.data.isUserLogged;
  socialUser!: SocialUser;
  authRequest: AuthRequest = {
    provider: '',
    idToken: '',
  }

  constructor(@Inject(MAT_DIALOG_DATA) public data: any, private socialAuthService: SocialAuthService, private toastr: ToastrService, private apiService: ApiService) { }

  ngOnInit(): void {
    this.socialAuthService.authState.subscribe((user) => {
      this.socialUser = user
      if (this.socialUser !== null) {
        this.authRequest.idToken = this.socialUser.idToken;
        this.authRequest.provider = this.socialUser.provider;
        this.apiService.getAccessToken(this.authRequest).subscribe({
          next: (res) => {
            this.isUserLogged = true;
            localStorage.setItem('token', res.data['result'])
            localStorage.setItem('user', JSON.stringify(this.socialUser))
            this.apiService.UpdateToken(res.data['result'])
          }
        })
      }
    })
  }

  loginWithMicrosoft() {
    this.socialAuthService.signIn(MicrosoftLoginProvider.PROVIDER_ID).then(user => {
      this.socialUser = user;
      if (this.socialUser) {
        this.isUserLogged = true;
      }
    });
  }

  confirmBooking() {
    this.apiService.bookMovie(this.bookingDetails).subscribe(
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
