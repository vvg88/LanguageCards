﻿import { Component, Inject, } from '@angular/core';
import { Router } from '@angular/router';
import { Http } from '@angular/http';
import { AppRoutes } from '../../shared/routes';
import Card from '../../shared/models/card';
import Answer from '../../shared/models/answer';
import TestCardComponent from '../testcard/testcard.component';
import CardsService from '../../services/cards.service';
import AnsweredCard from '../../shared/models/answeredCard';

@Component({
    selector: 'test',
    templateUrl: './test.component.html',
    styleUrls: ['./test.component.css'],
})
export default class TestComponent {
    public cards: AnsweredCard[] = [];
    private cardsService: CardsService;
    private router: Router;

    constructor(cardsService: CardsService, router: Router) {
        this.cardsService = cardsService;
        this.router = router;
        this.cardsService.getCards().then(cards => this.getCards(cards), error => console.error(error));
    }
    
    submitAnswers() {
        this.cardsService.postCards(this.getAnswers()).then(response => response.subscribe(result => {
            this.router.navigateByUrl(AppRoutes.mainAppCards);
        }, error => console.error(error)));
    }

    private getCards(cards: Card[]) {
        this.cards = cards.map((card) => {
            let ac: AnsweredCard = {
                cardId: card.id,
                wordDefinition: card.word.definition,
                speechPart: card.word.speechPart.name,
                translations: card.word.translations.map(t => t.text), answer: ""
            };
            return ac;
        });
    }

    private getAnswers(): Answer[] {
        return this.cards.map(c => {
            let answ = new Answer();
            answ.cardId = c.cardId;
            answ.answerText = c.answer;
            return answ;
        });
    }
}
