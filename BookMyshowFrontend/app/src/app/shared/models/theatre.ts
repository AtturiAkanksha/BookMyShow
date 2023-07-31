export class Theatre {
    id: number;
    theatreName: string;
    theatreRows: number;
    theatreColumns: number;
    movieTimings: string;
    ticketPrice: number;
    constructor(id: number, theatreName: string, theatreRows: number, theatreColumns: number, movieTimings: string, ticketPrice: number) {
        this.id = id;
        this.theatreName = theatreName;
        this.theatreRows = theatreRows,
            this.theatreColumns = theatreColumns,
            this.movieTimings = movieTimings,
            this.ticketPrice = ticketPrice
    }
}