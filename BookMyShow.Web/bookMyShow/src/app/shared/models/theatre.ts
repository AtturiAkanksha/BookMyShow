export class Theatre {
    id: number;
    name: string;
    rows: number;
    columns: number;
    movieIds: number[];
    movieTimings: string;
    location: string;
    ticketPrice: number;
    constructor(id: number, name: string, location: string, movieIds: number[], rows: number, columns: number, movieTimings: string, ticketPrice: number) {
        this.id = id;
        this.name = name;
        this.rows = rows;
        this.columns = columns;
        this.movieTimings = movieTimings;
        this.ticketPrice = ticketPrice;
        this.movieIds = movieIds;
        this.location = location;
    }
}