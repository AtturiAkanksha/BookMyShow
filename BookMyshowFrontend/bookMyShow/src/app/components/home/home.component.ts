import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { Movie } from 'src/app/shared/models/movie';
import { Theatre } from 'src/app/shared/models/theatre';
import { authService } from 'src/app/shared/services/auth.service';

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
  movieId: number =0;
  theatres: Theatre[] =[]

  constructor(private authService: authService, private router: Router) { }
  
  receiveData(data: Movie[]) {
    this.movies = data;
  }
  
  onMovieClick(id: number, movieName: string) {
    this.movieName = movieName;
    this.movieId = id;
    this.authService.getTheatres(id).subscribe(
      {
        next:
          (res: Theatre[]) => {
            this.theatres = res
          }
      })
    this.isDivVisible = !this.isDivVisible
  }

  onBookTicketsClick(theatreId:number) {
    const theatre:Theatre = this.theatres.find(theatre =>theatre.id == theatreId)!
    localStorage.clear();
    localStorage.setItem('theatreData', JSON.stringify(theatre));
    localStorage.setItem('movieId', JSON.stringify(this.movieId));
    localStorage.setItem('movieName', JSON.stringify(this.movieName));
    this.router.navigate(['/seating']);
  }
}