import { Inject, Injectable } from '@angular/core';
import { Http } from '@angular/http';
import { SignInCredentials } from '../shared/classes/signInCredentials';
import { Observable } from 'rxjs/Observable';

@Injectable()
export class SignInService {
    private http: Http;
    private baseUrl: string;
    private signInUrl: string = 'api/account/sign-in';

    constructor(http: Http,
                @Inject('BASE_URL') baseUrl: string) {
        this.http = http;
        this.signInUrl = baseUrl + this.signInUrl;
    }

    public async signIn(signInCredentials: SignInCredentials) {
        return await this.http.post(this.signInUrl, signInCredentials);
    }
}