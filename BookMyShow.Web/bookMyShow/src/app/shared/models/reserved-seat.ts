export class ReservedSeat {
    theatreId: number;
    movieTime: string;
    seatNumber: number;
    constructor(seatNumber: number, movieTime: string, theatreId: number) {
        this.theatreId = theatreId;
        this.movieTime = movieTime;
        this.seatNumber = seatNumber;
    }
}