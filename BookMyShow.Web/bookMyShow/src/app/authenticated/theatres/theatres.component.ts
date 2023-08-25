import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ApiService } from 'src/app/shared/services/api.service';
import { Theatre } from 'src/app/shared/models/theatre';
import { ResponseData } from 'src/app/shared/models/response-data';

@Component({
  selector: 'app-theatres',
  templateUrl: './theatres.component.html',
  styleUrls: ['./theatres.component.scss']
})

export class TheatresComponent {
  id: number = 0;
  name: string = '';
  movieId: number = 0;
  movieName: string = '';
  theatres: Theatre[] = [];
  response: ResponseData = {
    data: null,
    isSuccess: false,
    status: 200,
    error: ''
  }

  constructor(private route: ActivatedRoute, private apiService: ApiService) { }

  ngOnInit(): void {
    this.route.params.subscribe(params => {
      this.movieId = params['movieId'];
      this.movieName = params['movieName'];
      this.apiService.getTheatres(this.movieId).subscribe({
        next:
          (res) => {
            this.response = res
            this.theatres = this.response.data
          }
      });
    })
  }
}
