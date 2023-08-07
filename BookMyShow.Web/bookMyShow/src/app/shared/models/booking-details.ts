export class BookingDetails {
    movieId: number;
    movieName: string;
    theatreName: string;
    theatreId: number;
    movieTimings: string;
    totalAmount: number;
    date: Date;
    seatsCount: number;
    seatNumbers: number[];
    constructor(movieName: string, movieId: number, theatreName: string,
        movieTimings: string, totalAmount: number, theatreId: number, date: Date,
        seatsCount: number, seatNumbers: number[]) {
        this.theatreName = theatreName;
        this.movieTimings = movieTimings;
        this.movieName = movieName;
        this.theatreId = theatreId;
        this.totalAmount = totalAmount;
        this.date = date;
        this.seatsCount = seatsCount;
        this.seatNumbers = seatNumbers;
        this.movieId = movieId;
    }
}