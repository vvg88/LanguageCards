import { Component, Inject } from '@angular/core';
import { Http } from '@angular/http';
import { SignInCredentials } from '../../models/signInCredentials'

@Component({
    selector: 'signin',
    templateUrl: './signin.component.html'
})

export class SigninComponent {
    public signInCredentials: SignInCredentials = {
        email: "",
        password: "",
    };
    private http: Http;
    private baseUrl: string;
    public signInResult: string = "";

    constructor(http: Http, @Inject('BASE_URL') baseUrl: string) {
        this.http = http;
        this.baseUrl = baseUrl;
    }

    public signIn() {
        const url: string = this.baseUrl + 'api/account/sign-in';
        this.http.post(this.baseUrl + 'api/account/sign-in', this.signInCredentials).subscribe(result => {
            this.signInResult = result.ok ? "Success!" : "Error!";
        });
    }
}
