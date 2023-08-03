import { Component, EventEmitter, Output } from '@angular/core';
import { Movie } from 'src/app/shared/models/movie';
import { authService } from 'src/app/shared/services/auth.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss']
})
export class HeaderComponent {
  logo: string = 'assets/bookmyshow-logo.svg'
  selectedValue: string = '';
  serviceOutput: any;
  tmpObj: Movie[] = [];
  movies: Movie[] = [];

  @Output() dataEvent = new EventEmitter<Movie[]>();

  constructor(private authService: authService) { }

  onSelectChange() {
    this.authService.getMovies(this.selectedValue).subscribe({
      next:
        (res) => {
          this.serviceOutput = res;
          this.serviceOutput.forEach((element: Movie) => {
            this.pushMovies(element);
          }
          ),
            this.movies = this.tmpObj;
          this.dataEvent.emit(this.movies);
        }
    });
  }

  pushMovies(element: Movie) {
    this.tmpObj.push(
      {
        id: element.id,
        movieName: element.movieName,
        languages: element.languages,
        hours: element.hours,
        genre: element.genre,
        dateOfRelease: element.dateOfRelease,
        locationNames: element.locationNames,
      })
  }

}