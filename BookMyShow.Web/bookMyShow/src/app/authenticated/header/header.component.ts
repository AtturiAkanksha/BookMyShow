import { FacebookLoginProvider, MicrosoftLoginProvider, SocialAuthService, SocialUser } from '@abacritt/angularx-social-login';
import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { ApiService } from 'src/app/shared/services/api.service';
import { AuthRequest } from 'src/app/shared/models/auth-request'

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
  name!: string;
  authRequest: AuthRequest = {
    provider: '',
    idToken: '',
  }

  constructor(private socialAuthService: SocialAuthService, private apiService: ApiService, private toastr: ToastrService,
  ) { }

  ngOnInit(): void {
    this.socialAuthService.authState.subscribe((user) => {
      this.socialUser = user
      if (this.socialUser != null) {
        this.authRequest.idToken = this.socialUser.idToken;
        this.authRequest.provider = this.socialUser.provider;
        this.apiService.getAccessToken(this.authRequest).subscribe({
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

  loginWithMicrosoft() {
    this.socialAuthService.signIn(MicrosoftLoginProvider.PROVIDER_ID).then(user => {
      this.socialUser = user;
    });
  }

  loginWithFacebook() {
    this.socialAuthService.signIn(FacebookLoginProvider.PROVIDER_ID);
  }

  signOut() {
    this.socialAuthService.signOut().then(() => {
      localStorage.clear();
      this.isLoggedIn = false;
      this.apiService.UpdateToken('');
    }).catch(() => {
      this.toastr.error('Sorry! Unable to logout')
    })
  }
}