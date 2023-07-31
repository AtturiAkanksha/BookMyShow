import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { BookingDetails } from '../models/booking-details';
import { Movie } from '../models/movie';
import { ReservedSeat } from '../models/reserved-seats';
import { Theatre } from '../models/theatre';

@Injectable({
  providedIn: 'root'
})
export class authService {
  apiUrl: string = "https://localhost:7269/api"
  headers = new HttpHeaders({ 'Content-Type': 'application/json' });

  constructor(private http: HttpClient) { }

  public getMovies(locationName: string): Observable<Movie> {
    const body = JSON.stringify(locationName);
    const baseServerUrl = `${this.apiUrl}/Movies/getMovies`;
    return this.http.post<Movie>(baseServerUrl, body, { headers: this.headers })
  }

  public getTheatres(id: number): Observable<Theatre> {
    const baseServerUrl = `${this.apiUrl}/Theatre/${id}`;
    return this.http.get<Theatre>(baseServerUrl, { headers: this.headers })
  }
  
  public getReservedSeats(): Observable<ReservedSeat[]> {
    const baseServerUrl = `${this.apiUrl}/Theatre/getReservedSeatsData`;
    return this.http.get<ReservedSeat[]>(baseServerUrl, { headers: this.headers })
  }

  public sendBookedDetails(data: BookingDetails): Observable<BookingDetails> {
    const baseServerUrl = `${this.apiUrl}/Booking/BookMovie`;
    return this.http.post<BookingDetails>(baseServerUrl, data, { headers: this.headers })
  }
}
