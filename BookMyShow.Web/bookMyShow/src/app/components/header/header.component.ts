import { SocialAuthService } from '@abacritt/angularx-social-login';
import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss']
})
export class HeaderComponent {
  logo: string = 'assets/bookmyshow-logo.svg'

  constructor(private socialAuthService: SocialAuthService, private router:Router, private toastr: ToastrService) { }

  signOut(){
    this.socialAuthService.signOut().then(() => {
      this.router.navigate(['/']);
    }).catch(() => {
      this.toastr.error('Sorry! Unable to logout')
  })
  }
}