import { Inject, Injectable } from '@angular/core';
import { Http } from '@angular/http';
import SignInCredentials from '../shared/models/signInCredentials';
import { AppRoutes } from '../shared/routes';
import HttpHelper from '../utils/httpHelper';

@Injectable()
export default class SignInService extends HttpHelper {
    private signInUrl: string = AppRoutes.apiAccSignIn;

    constructor(http: Http) {
        super(http);
        this.signInUrl = this.baseUrl + this.signInUrl;
    }

    public async signIn(signInCredentials: SignInCredentials): Promise<boolean> {
        let resp = await this.postAction(this.signInUrl, signInCredentials);
        return await new Promise<boolean>((resolve, reject) => resp.subscribe(result => resolve(result.ok), error => reject(error)));
    }
}