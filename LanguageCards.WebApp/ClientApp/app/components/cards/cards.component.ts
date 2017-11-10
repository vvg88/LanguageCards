import { Component, Inject } from '@angular/core';
import { Http } from '@angular/http';

@Component({
    selector: 'cards',
    templateUrl: './cards.component.html'
})
export class CardsComponent {
    public cards: Cards[];

    constructor(http: Http, @Inject('BASE_URL') baseUrl: string) {
        http.get(baseUrl + 'api/Cards/GetCards').subscribe(result => {
            this.cards = result.json() as Cards[];
        }, error => console.error(error));
    }
}

interface Cards {
    word: string
    definition: string
    example: string
}
