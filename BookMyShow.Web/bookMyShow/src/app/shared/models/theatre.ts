export class Theatre {
    id: number;
    name: string;
    rows: number;
    columns: number;
    movieIds: number[];
    showTime: string;
    location: string;
    ticketPrice: number;
    constructor(id: number, name: string, location: string, movieIds: number[], rows: number, columns: number, showTime: string, ticketPrice: number) {
        this.id = id;
        this.name = name;
        this.rows = rows;
        this.columns = columns;
        this.showTime = showTime;
        this.ticketPrice = ticketPrice;
        this.movieIds = movieIds;
        this.location = location;
    }
}