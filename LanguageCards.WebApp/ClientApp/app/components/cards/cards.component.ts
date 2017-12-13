﻿import { Component, Inject } from '@angular/core';
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
        cardsService.getCards().then(response => response.subscribe(result => {
            this.cards = result.json() as Card[];
        }, error => console.error(error)));
    }
}
