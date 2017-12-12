import { Component, Inject, } from '@angular/core';
import { Router } from '@angular/router';
import { Http } from '@angular/http';
import { Card } from '../../shared/classes/card';
import { Answer } from '../../shared/classes/answer';
import { TestCardComponent } from '../testcard/testcard.component';
import { CardsService } from '../../services/cards.service';
import { AppRoutes } from '../../shared/classes/routes';
import { AnsweredCard } from '../../shared/classes/answeredCard';

@Component({
    selector: 'test',
    templateUrl: './test.component.html',
    styleUrls: ['./test.component.css'],
})
export class TestComponent {
    public cards: AnsweredCard[] = [];
    private cardsService: CardsService;
    private router: Router;

    constructor(cardsService: CardsService, router: Router) {
        this.cardsService = cardsService;
        this.router = router;
        this.cardsService.getCards().then(response => response.subscribe(result => {
            this.getCards(result.json() as Card[]);
        }, error => console.error(error)));
    }
    
    submitAnswers() {
        this.cardsService.postCards(this.getAnswers()).then(response => response.subscribe(result => {
            this.router.navigateByUrl(AppRoutes.mainAppCards);
        }, error => console.error(error)));
    }

    private getCards(cards: Card[]) {
        this.cards = cards.map((card) =>
            new AnsweredCard(card.id, card.word.definition, card.word.speechPart.name, card.word.translations.map(t => t.text)));
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
