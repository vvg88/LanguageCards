﻿import { Inject, Injectable } from '@angular/core';
import { Http } from '@angular/http';
import SignInCredentials from '../shared/models/signInCredentials';
import { AppRoutes } from '../shared/routes';
import HttpHelper from '../utils/httpHelper';

@Injectable()
export default class SignInService extends HttpHelper {
    private signInUrl: string = AppRoutes.apiAccSignIn;

    constructor(http: Http, @Inject('BASE_URL') baseUrl: string) {
        super(http);
        this.signInUrl = baseUrl + this.signInUrl;
    }

    public async signIn(signInCredentials: SignInCredentials) {
        return await this.postAction(this.signInUrl, signInCredentials);
    }
}