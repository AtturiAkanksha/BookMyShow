import { Seat } from "./seat";

export class ReservedSeat extends Seat {
    theatreId: number;
    movieTime: string;
    constructor(isReserved: boolean, isDisabled: boolean, seatNumber: number,
        movieTime: string, theatreId: number) {
        super(seatNumber, isReserved, isDisabled)
        this.theatreId = theatreId;
        this.movieTime = movieTime;
        this.seatNumber = seatNumber;
    }
}