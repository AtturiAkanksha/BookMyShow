import { SocialAuthService } from '@abacritt/angularx-social-login';
import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { ApiService } from 'src/app/shared/services/api.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})

export class LoginComponent {
  accessToken:string='';

  constructor(private socialAuthService: SocialAuthService, private router:Router,  private apiService:ApiService) { }

  ngOnInit() {
    this.socialAuthService.authState.subscribe((user) => {
      if (user !== null) {
        this.apiService.getAccessToken(user.idToken).subscribe({
          next:(res)=> console.log(res.data)
        })
        this.router.navigate(['/home'])
      }
    });
  }

}
