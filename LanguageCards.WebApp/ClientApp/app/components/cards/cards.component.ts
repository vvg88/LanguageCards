import { Component, Inject } from '@angular/core';
import { Http } from '@angular/http';
import Card = CardModule.Card;

@Component({
    selector: 'cards',
    templateUrl: './cards.component.html'
})
export class CardsComponent {
    public cards: Card[];

    constructor(http: Http, @Inject('BASE_URL') baseUrl: string) {
        http.get(baseUrl + 'api/Cards/GetCards').subscribe(result => {
            this.cards = result.json() as Card[];
        }, error => console.error(error));
    }
}

interface Cards {
    word: string
    definition: string
    example: string
}
