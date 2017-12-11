import { Component, Inject } from '@angular/core';
import { Http } from '@angular/http';
import { Card } from '../../shared/classes/card';

@Component({
    selector: 'cards',
    templateUrl: './cards.component.html'
})
export class CardsComponent {
    public cards: Card[] = [];

    constructor(http: Http, @Inject('BASE_URL') baseUrl: string) {
        http.get(baseUrl + 'api/cards').subscribe(result => {
            this.cards = result.json() as Card[];
        }, error => console.error(error));
    }
}
