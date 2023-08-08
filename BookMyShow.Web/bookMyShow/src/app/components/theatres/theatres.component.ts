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
      const param1Value = params['movieId'];
      this.apiService.getTheatres(param1Value).subscribe({
        next:
          (res) => {
            this.response = res
            this.theatres = this.response.data
          }
      });
    })
  }
}
