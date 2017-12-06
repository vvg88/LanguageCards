import { Component, Inject } from '@angular/core';
import { Router } from '@angular/router';
import { Http } from '@angular/http';
import { SignInCredentials } from '../../models/signInCredentials'

@Component({
    selector: 'signin',
    templateUrl: './signin.component.html',
    styleUrls: ['./signin.component.css'],
})

export class SigninComponent {
    public signInCredentials: SignInCredentials = {
        email: "",
        password: "",
    };
    public signInResult: string = "";

    private http: Http;
    private baseUrl: string;
    private router: Router;

    constructor(http: Http,
                @Inject('BASE_URL') baseUrl: string,
                router: Router) {
        this.http = http;
        this.baseUrl = baseUrl;
        this.router = router;
    }

    public signIn() {
        const url: string = this.baseUrl + 'api/account/sign-in';
        this.http.post(this.baseUrl + 'api/account/sign-in', this.signInCredentials).subscribe(result => {
            if (result.ok) {
                this.signInResult = "Success!";
                this.router.navigateByUrl('/mainapp/(cardList:cards)');
            }
            else {
                this.signInResult = "Error!";
            }
            
        });
    }
}
