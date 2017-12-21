import { Http, Headers, RequestOptions } from '@angular/http';
import { RequestOptionsArgs } from '@angular/http';
import { getBaseUrl } from '../app.module.browser';

export default class HttpHelper {
    private http: Http;
    private reqOptions: RequestOptionsArgs;
    protected baseUrl: string;

    constructor(http: Http) {
        this.http = http;
        this.baseUrl = getBaseUrl();

        let jwt = sessionStorage['access_token'];
        if (jwt == null) {
            jwt = localStorage['access_token'];
        }
        let headers = new Headers({ 'Authorization': 'Bearer ' + jwt });
        this.reqOptions = new RequestOptions({ headers: headers });
        console.log(this.reqOptions);
    }

    protected async postAction(url: string, body: any) {
        return await this.http.post(url, body, this.reqOptions);
    }

    protected async getAction(url: string) {
        return await this.http.get(url, this.reqOptions);
    }
}