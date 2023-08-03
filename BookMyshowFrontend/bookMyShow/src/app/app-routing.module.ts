import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './components/home/home.component';
import { SeatingComponent } from './components/seating/seating.component';

const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'seating', component: SeatingComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
