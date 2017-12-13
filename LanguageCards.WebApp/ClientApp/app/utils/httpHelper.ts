import { Http } from '@angular/http';

export default class HttpHelper {
    private http: Http;

    constructor(http: Http) {
        this.http = http;
    }

    protected async postAction(url: string, body: any) {
        return await this.http.post(url, body);
    }

    protected async getAction(url: string) {
        return await this.http.get(url);
    }
}