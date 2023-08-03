import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { BookingDetails } from '../models/booking-details';
import { Movie } from '../models/movie';
import { ReservedSeat } from '../models/reserved-seat';
import { Theatre } from '../models/theatre';

@Injectable({
  providedIn: 'root'
})

export class authService {

  apiUrl: string = "https://localhost:7269/api"
  headers = new HttpHeaders({ 'Content-Type': 'application/json' });
  baseServerUrl = "";
  constructor(private http: HttpClient) { }

  public getMovies(locationName: string): Observable<Movie> {
    const body = JSON.stringify(locationName);
    this.baseServerUrl = `${this.apiUrl}/Movies/getMovies`;
    return this.http.post<Movie>(this.baseServerUrl, body, { headers: this.headers })
  }

  public getTheatres(id: number): Observable<Theatre[]> {
    this.baseServerUrl = `${this.apiUrl}/Theatre/getTheatres`;
    return this.http.post<Theatre[]>(this.baseServerUrl, id, { headers: this.headers })
  }

  public getReservedSeats(): Observable<ReservedSeat[]> {
    this.baseServerUrl = `${this.apiUrl}/Theatre/getReservedSeatsData`;
    return this.http.get<ReservedSeat[]>(this.baseServerUrl, { headers: this.headers })
  }

  public sendBookedDetails(data: BookingDetails): Observable<BookingDetails> {
    this.baseServerUrl = `${this.apiUrl}/Booking/BookMovie`;
    return this.http.post<BookingDetails>(this.baseServerUrl, data, { headers: this.headers })
  }
}
