import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { BookingDetails } from '../models/booking-details';
import { ReservedSeat } from '../models/reserved-seat';
import { ResponseData } from '../models/response-data';

@Injectable({
  providedIn: 'root'
})

export class ApiService {

  apiUrl: string = "https://localhost:7269/api"
  baseServerUrl = "";

  constructor(private http: HttpClient) { }

  public getAccessToken(idToken : string){
    this.baseServerUrl = `${this.apiUrl}/User/getToken`;
    return this.http.get<ResponseData>(this.baseServerUrl, { params: { idToken: idToken } })
  }

  public getMovies(locationName: string): Observable<ResponseData> {
    this.baseServerUrl = `${this.apiUrl}/Movies/getMovies`;
    return this.http.get<ResponseData>(this.baseServerUrl, { params: { location: locationName } })
  }

  public getTheatres(id: number): Observable<ResponseData> {
    this.baseServerUrl = `${this.apiUrl}/Theatre/getTheatres`;
    return this.http.get<ResponseData>(this.baseServerUrl, { params: { id } })
  }

  public getTheatreById(id: number): Observable<ResponseData> {
    this.baseServerUrl = `${this.apiUrl}/Theatre/${id}`;
    return this.http.get<ResponseData>(this.baseServerUrl)
  }

  public reservedSeats(request: ReservedSeat): Observable<ResponseData> {
    this.baseServerUrl = `${this.apiUrl}/Theatre/reservedSeatsData`;
    return this.http.post<ResponseData>(this.baseServerUrl, request);
  }

  public bookMovie(data: BookingDetails): Observable<ResponseData> {
    this.baseServerUrl = `${this.apiUrl}/Booking/bookMovie`;
    return this.http.post<ResponseData>(this.baseServerUrl, data)
  }
}
