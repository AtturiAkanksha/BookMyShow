export class AuthRequest {
    provider: string;
    idToken: string;
    constructor(provider: string, idToken: string
    ) {
        this.provider = provider;
        this.idToken = idToken;
    }
}