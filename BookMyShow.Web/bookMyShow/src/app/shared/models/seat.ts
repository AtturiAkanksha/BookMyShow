export class Seat {
    seatNumber: string;
    isReserved: boolean;
    isDisabled: boolean;
    constructor(seatNumber: string,
        isReserved: boolean, isDisabled: boolean) {
        this.seatNumber = seatNumber;
        this.isReserved = isReserved;
        this.isDisabled = isDisabled;
    }
}