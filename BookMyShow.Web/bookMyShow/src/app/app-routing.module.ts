import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './components/home/home.component';
import { SeatingLayoutComponent } from './components/seating-layout/seating-layout.component';
import { TheatresComponent } from './components/theatres/theatres.component';

const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'theatres/:movieId/:movieName', component: TheatresComponent},
  { path: 'theatre/:movieId/:movieName/:id/:name', component: SeatingLayoutComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
