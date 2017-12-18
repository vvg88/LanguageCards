import { Inject, Injectable } from '@angular/core';
import { Http } from '@angular/http';
import { AppRoutes } from '../shared/routes';
import HttpHelper from '../utils/httpHelper';
import Card from '../shared/models/card';
import Answer from '../shared/models/answer';

@Injectable()
export default class CardsService extends HttpHelper {
    private cardsApiUrl: string = 'api/cards';

    constructor(http: Http) {
        super(http);
        this.cardsApiUrl = this.baseUrl + this.cardsApiUrl;
    }

    public async getCards(): Promise<Card[]> {
        let resp = await this.getAction(this.cardsApiUrl);
        return await new Promise<Card[]>((resolve, reject) => resp.subscribe(result => resolve(result.json() as Card[]), error => reject(error)));
    }

    public async postCards(body: Answer[]) {
        return await this.postAction(this.cardsApiUrl, body);
    }
}