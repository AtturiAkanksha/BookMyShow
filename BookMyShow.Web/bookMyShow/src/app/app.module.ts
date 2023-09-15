import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HomeComponent } from './authenticated/home/home.component';
import { HeaderComponent } from './authenticated/header/header.component';
import { SlickCarouselModule } from 'ngx-slick-carousel';
import { FormsModule } from '@angular/forms';
import { SharedModule } from './shared/shared.module';
import { SeatingLayoutComponent } from './authenticated/seating-layout/seating-layout.component';
import { NoopAnimationsModule } from '@angular/platform-browser/animations';
import { PopupComponent } from './authenticated/popup/popup.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatDialogModule } from '@angular/material/dialog';
import { TheatresComponent } from './authenticated/theatres/theatres.component';
import { SeatComponent } from './authenticated/seat/seat.component';
import { ToastrModule } from 'ngx-toastr';
import { SocialLoginModule, SocialAuthServiceConfig, FacebookLoginProvider, MicrosoftLoginProvider } from '@abacritt/angularx-social-login';
import { GoogleLoginProvider } from '@abacritt/angularx-social-login';
import { CommonModule } from '@angular/common';
import { AuthenticatedModule } from './authenticated/authenticated.module';
import { UnAuthenticatedModule } from './un-authenticated/un-authenticated.module';
import { environment } from 'src/environment';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    HeaderComponent,
    SeatingLayoutComponent,
    PopupComponent,
    TheatresComponent,
    SeatComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    SlickCarouselModule,
    FormsModule,
    SharedModule,
    NoopAnimationsModule,
    BrowserAnimationsModule,
    MatDialogModule,
    SocialLoginModule,
    CommonModule,
    AuthenticatedModule,
    UnAuthenticatedModule,
    ToastrModule.forRoot()
  ],
  providers: [
    {
      provide: 'SocialAuthServiceConfig',
      useValue: {
        autoLogin: true,
        providers: [
          {
            id: GoogleLoginProvider.PROVIDER_ID,
            provider: new GoogleLoginProvider(environment.googleClientId),
          },
          {
            id: FacebookLoginProvider.PROVIDER_ID,
            provider: new FacebookLoginProvider(environment.facebookClientId),
          },
          {
            id: MicrosoftLoginProvider.PROVIDER_ID,
            provider: new MicrosoftLoginProvider(environment.microsoftClientId),
          },
        ],
        onError: (err) => {
          console.log(err);
        }
      } as SocialAuthServiceConfig,
    },
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
