export class Seat {
    seatNumber: number;
    isReserved: boolean;
    isDisabled: boolean;
    constructor(seatNumber: number,
        isReserved: boolean, isDisabled: boolean) {
        this.seatNumber = seatNumber;
        this.isReserved = isReserved;
        this.isDisabled = isDisabled
    }
}