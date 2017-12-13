import { Inject, Injectable } from '@angular/core';
import { Http } from '@angular/http';
import { AppRoutes } from '../shared/routes';
import HttpHelper from '../utils/httpHelper';

@Injectable()
export default class CardsService extends HttpHelper {
    private cardsApiUrl: string = AppRoutes.apiCards;

    constructor(http: Http, @Inject('BASE_URL') baseUrl: string) {
        super(http);
        this.cardsApiUrl = baseUrl + this.cardsApiUrl;
    }

    public async getCards() {
        return await this.getAction(this.cardsApiUrl);
    }

    public async postCards(body: any) {
        return await this.postAction(this.cardsApiUrl, body);
    }
}