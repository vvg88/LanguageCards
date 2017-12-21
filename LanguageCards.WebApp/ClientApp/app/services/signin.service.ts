import { Inject, Injectable } from '@angular/core';
import { Http } from '@angular/http';
import SignInCredentials from '../shared/models/signInCredentials';
import { AppRoutes } from '../shared/routes';
import HttpHelper from '../utils/httpHelper';

@Injectable()
export default class SignInService extends HttpHelper {
    private signInUrl: string = 'api/account/sign-in';

    constructor(http: Http) {
        super(http);
        this.signInUrl = this.baseUrl + this.signInUrl;
    }

    public async signIn(signInCredentials: SignInCredentials, rememberMe: boolean): Promise<boolean> {
        let resp = await this.postAction(this.signInUrl, signInCredentials);
        return await new Promise<boolean>((resolve, reject) =>
            resp.subscribe(result => {
                if (result.ok) this.saveJwt(result.json().access_token, rememberMe);
                resolve(result.ok);
            }, error => reject(error)));
    }

    private saveJwt(accessTok: string, rememberMe: boolean) {
        localStorage.removeItem('access_token');
        sessionStorage.removeItem('access_token');
        if (rememberMe) {
            localStorage['access_token'] = accessTok;
        } else {
            sessionStorage['access_token'] = accessTok;
        }
    }
}