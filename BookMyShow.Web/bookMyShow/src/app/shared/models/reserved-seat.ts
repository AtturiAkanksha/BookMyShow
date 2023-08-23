import { Seat } from "./seat";

export class ReservedSeat extends Seat {
    theatreId: number;
    movieId: number;
    showTime: string;
    constructor(isReserved: boolean, isDisabled: boolean, seatNumber: string, movieId: number,
        showTime: string, theatreId: number) {
        super(seatNumber, isReserved, isDisabled)
        this.theatreId = theatreId;
        this.showTime = showTime;
        this.seatNumber = seatNumber;
        this.movieId = movieId
    }
}