import { HttpStatusCode } from "@angular/common/http"

export class ResponseData {
    data: any;
    isSuccess: boolean;
    status: HttpStatusCode;
    error: string;
    constructor(data: any, isSuccess: boolean, status: HttpStatusCode, error: string) {
        this.status = status;
        this.isSuccess = isSuccess;
        this.data = data;
        this.error = error;
    }
}