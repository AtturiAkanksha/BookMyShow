import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { SeatingLayoutComponent } from './seating-layout/seating-layout.component';
import { TheatresComponent } from './theatres/theatres.component';

const routes: Routes = [
  { path: 'home', component: HomeComponent },
  { path: 'theatres/:movieId/:movieName', component: TheatresComponent },
  { path: 'theatre/:movieId/:movieName/:id/:name', component: SeatingLayoutComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AuthenticatedRoutingModule { }
