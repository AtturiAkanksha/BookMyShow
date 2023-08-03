export class ReservedSeat {
    id: number;
    seatNumber: number;
    theatreId: number;
    constructor(id: number, seatNumber: number, theatreId: number) {
        this.id = id
        this.seatNumber = seatNumber;
        this.theatreId = theatreId;
    }
}