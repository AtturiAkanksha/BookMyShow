import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { Movie } from 'src/app/shared/models/movie';
import { Theatre } from 'src/app/shared/models/theatre';
import { authService } from 'src/app/shared/services/auth.service';
import { DataService } from 'src/app/shared/services/data.service';
@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent {

  avatar: string = "assets/movie-images/avatar.jpg";
  johnWick: string = "assets/movie-images/john-wick.jpg";
  joker: string = "assets/movie-images/joker.jpeg";
  movies: Movie[] = [];
  isDivVisible: boolean = false;
  movieName: string = '';
  theatre: Theatre = {
    id: 0,
    theatreName: '',
    theatreRows: 0,
    theatreColumns: 0,
    movieTimings: '',
    ticketPrice: 0
  };

  constructor(private authService: authService, private router: Router, private dataService: DataService) { }
  receiveData(data: Movie[]) {
    this.movies = data;
  }
  
  onMovieClick(id: number, movieName: string) {
    this.movieName = movieName;
    this.authService.getTheatres(id).subscribe(
      {
        next:
          (res: Theatre) => {
            this.theatre = res
          }
      })
    this.isDivVisible = !this.isDivVisible
  }

  onBookTicketsClick() {
    this.dataService.setData(this.theatre, this.movieName);
    this.router.navigate(['/seating']);
  }
}