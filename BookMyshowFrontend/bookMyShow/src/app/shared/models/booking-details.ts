import { Time } from "@angular/common";

export class BookingDetails {
    movieId: number;
    movieName: string;
    theatreName: string;
    theatreId: number;
    movieTimings: string;
    totalAmount: number;
    date: Date;
    seatsCount: number;
    seatNames: number[];
    constructor(movieName: string, movieId: number, theatreName: string,
        movieTimings: string, totalAmount: number, theatreId: number, date: Date,
        seatsCount: number, seatNames: number[]) {
        this.theatreName = theatreName;
        this.movieTimings = movieTimings;
        this.movieName = movieName;
        this.theatreId = theatreId
        this.totalAmount = totalAmount;
        this.date = date;
        this.seatsCount = seatsCount;
        this.seatNames = seatNames
        this.movieId = movieId
    }
}