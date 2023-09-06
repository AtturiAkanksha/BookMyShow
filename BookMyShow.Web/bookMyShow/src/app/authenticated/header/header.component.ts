import { FacebookLoginProvider, SocialAuthService, SocialUser } from '@abacritt/angularx-social-login';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { ApiService } from 'src/app/shared/services/api.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss']
})

export class HeaderComponent implements OnInit {
  logo: string = 'assets/bookmyshow-logo.svg'
  accessToken: string = '';
  isLoggedIn: boolean = false;
  socialUser!: SocialUser;

  constructor(private socialAuthService: SocialAuthService, private apiService: ApiService, private router: Router, private toastr: ToastrService) { }

  ngOnInit(): void {
    this.socialAuthService.authState.subscribe((user) => {
      this.socialUser = user
      if (this.socialUser !== null) {
        this.apiService.getAccessToken(this.socialUser.idToken).subscribe({
          next: (res) => {
            this.isLoggedIn = true;
            localStorage.setItem('token', res.data['result'])
            localStorage.setItem('user', JSON.stringify(this.socialUser))
            this.apiService.UpdateToken(res.data['result'])
          }
        })
      }
    })
  }

  loginWithFacebook() {
    this.socialAuthService.signIn(FacebookLoginProvider.PROVIDER_ID);
  }

  signOut() {
    this.socialAuthService.signOut().then(() => {
      localStorage.removeItem('token');
      localStorage.removeItem('user');
      this.isLoggedIn = false;
      this.apiService.UpdateToken('');
    }).catch(() => {
      this.toastr.error('Sorry! Unable to logout')
    })
  }
}