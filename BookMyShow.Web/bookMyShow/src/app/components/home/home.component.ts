import { Component } from '@angular/core';
import { Movie } from 'src/app/shared/models/movie';
import { ResponseData } from 'src/app/shared/models/response-data';
import { Theatre } from 'src/app/shared/models/theatre';
import { ApiService } from 'src/app/shared/services/api.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})

export class HomeComponent {

  name: string = '';
  id: number = 0;
  theatres: Theatre[] = []
  selectedValue: string = '';
  movies: Movie[] = [];
  isError: boolean = false;
  response: ResponseData =
    {
      data: null,
      isSuccess: false,
      status: 400,
      error: ''
    }

  constructor(private apiService: ApiService) { }

  onLocationChange() {
    this.apiService.getMovies(this.selectedValue).subscribe({
      next:
        (res) => {
          this.response = res;
          if (this.response.data != null) {
            this.movies = this.response.data;
          }
          else {
            this.movies=[];
            this.isError = true;
          }
        }
    });
  }
}