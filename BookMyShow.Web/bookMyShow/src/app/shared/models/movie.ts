export class Movie {
    id: number;
    name: string;
    language: string;
    hours: string;
    genre: string;
    dateOfRelease: Date;
    constructor(id: number, name: string, language: string, hours: string, genre: string, dateOfRelease: Date
    ) {
        this.id = id;
        this.name = name;
        this.language = language;
        this.hours = hours;
        this.genre = genre;
        this.dateOfRelease = dateOfRelease;
    }
}