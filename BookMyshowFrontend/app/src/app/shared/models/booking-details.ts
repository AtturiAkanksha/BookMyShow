export class BookingDetails {
    movieName: string;
    theatreName: string;
    theatreId: number;
    movieTimings: string;
    totalAmount: number;
    date: Date;
    totalSeats: number;
    seatNames: number[];
    constructor(movieName: string, theatreName: string,
        movieTimings: string, totalAmount: number, theatreId: number, date: Date,
        totalSeats: number, seatNames: number[]) {
        this.theatreName = theatreName;
        this.movieTimings = movieTimings;
        this.movieName = movieName;
        this.theatreId = theatreId
        this.totalAmount = totalAmount;
        this.date = date;
        this.totalSeats = totalSeats;
        this.seatNames = seatNames
    }
}