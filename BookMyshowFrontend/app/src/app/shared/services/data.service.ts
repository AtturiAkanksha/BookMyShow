import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class DataService {

  constructor() { }

  setData(data: any, movieName: string) {
    localStorage.removeItem('data');
    localStorage.removeItem('movieName');
    localStorage.setItem('data', JSON.stringify(data));
    localStorage.setItem('movieName', JSON.stringify(movieName));
  }

  getData(): any {
    return JSON.parse(localStorage.getItem('data') ?? "");
  }
}
