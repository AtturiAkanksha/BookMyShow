export class Movie {
    id: number;
    name: string;
    language: string;
    duration: string;
    genre: string;
    dateOfRelease: Date;
    constructor(id: number, name: string, language: string, duration: string, genre: string, dateOfRelease: Date
    ) {
        this.id = id;
        this.name = name;
        this.language = language;
        this.duration = duration;
        this.genre = genre;
        this.dateOfRelease = dateOfRelease;
    }
}