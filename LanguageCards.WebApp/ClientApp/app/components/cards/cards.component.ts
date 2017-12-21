import { Component, Inject } from '@angular/core';
import { Http } from '@angular/http';
import Card from '../../shared/models/card';
import CardsService from '../../services/cards.service';

@Component({
    selector: 'cards',
    templateUrl: './cards.component.html'
})
export default class CardsComponent {
    public cards: Card[] = [];

    constructor(cardsService: CardsService) {
        let accessTok = sessionStorage['access_token'];
        cardsService.getCards().then(cards => this.cards = cards).catch(error => console.error(error));
    }
}
