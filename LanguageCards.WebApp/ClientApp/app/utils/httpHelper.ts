import { Http } from '@angular/http';
import { getBaseUrl } from '../app.module.browser';

export default class HttpHelper {
    private http: Http;
    protected baseUrl: string;

    constructor(http: Http) {
        this.http = http;
        this.baseUrl = getBaseUrl();
    }

    protected async postAction(url: string, body: any) {
        return await this.http.post(url, body);
    }

    protected async getAction(url: string) {
        return await this.http.get(url);
    }
}