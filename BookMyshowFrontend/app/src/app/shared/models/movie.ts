export class Movie {
    id: number;
    movieName: string;
    languages: string;
    hours: string;
    genre: string;
    dateOfRelease: string;
    locationNames: string;
    constructor(id: number, movieName: string, languages: string, hours: string, genre: string, dateOfRelease: string, locationNames: string,
    ) {
        this.id = id;
        this.movieName = movieName;
        this.languages = languages;
        this.hours = hours;
        this.genre = genre;
        this.dateOfRelease = dateOfRelease;
        this.locationNames = locationNames;
    }
}