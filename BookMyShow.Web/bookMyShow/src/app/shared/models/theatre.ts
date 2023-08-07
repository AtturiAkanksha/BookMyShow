export class Theatre {
    id: number;
    theatreName: string;
    theatreRows: number;
    theatreColumns: number;
    movieIds: number[];
    movieTimings: string;
    locationName: string;
    ticketPrice: number;
    constructor(id: number, theatreName: string, locationName: string, movieIds: number[], theatreRows: number, theatreColumns: number, movieTimings: string, ticketPrice: number) {
        this.id = id;
        this.theatreName = theatreName;
        this.theatreRows = theatreRows;
        this.theatreColumns = theatreColumns;
        this.movieTimings = movieTimings;
        this.ticketPrice = ticketPrice;
        this.movieIds = movieIds;
        this.locationName = locationName;
    }
}