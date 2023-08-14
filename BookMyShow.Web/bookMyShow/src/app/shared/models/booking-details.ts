export class BookingDetails {
    movieId: number;
    movieName: string;
    theatreName: string;
    theatreId: number;
    showTime: string;
    totalAmount: number;
    date: Date;
    seatNumbers: string[];
    constructor(movieName: string, movieId: number, theatreName: string,
        showTime: string, totalAmount: number, theatreId: number, date: Date,
        seatNumbers: string[]) {
        this.theatreName = theatreName;
        this.showTime = showTime;
        this.movieName = movieName;
        this.theatreId = theatreId;
        this.totalAmount = totalAmount;
        this.date = date;
        this.seatNumbers = seatNumbers;
        this.movieId = movieId;
    }
}