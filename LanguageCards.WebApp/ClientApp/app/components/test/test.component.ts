import { Component, Inject, } from '@angular/core';
import { Router } from '@angular/router';
import { Http } from '@angular/http';
import { Card } from '../../shared/classes/card';
import { Answer } from '../../shared/classes/answer';
import { TestCardComponent } from '../testcard/testcard.component';
import { CardsService } from '../../services/cards.service';
import { AppRoutes } from '../../shared/classes/routes';

@Component({
    selector: 'test',
    templateUrl: './test.component.html',
    styleUrls: ['./test.component.css'],
})
export class TestComponent {
    public cards: Card[] = [];
    public answers: Answer[] = [{ answerText: "", cardId: 0 }, { answerText: "", cardId: 0 }, { answerText: "", cardId: 0 }, { answerText: "", cardId: 0 }, { answerText: "", cardId: 0 }];
    private cardsService: CardsService;
    private router: Router;

    constructor(cardsService: CardsService, router: Router) {
        this.cardsService = cardsService;
        this.router = router;
        this.cardsService.getCards().then(response => response.subscribe(result => {
            this.cards = result.json() as Card[];
        }, error => console.error(error)));
    }
    
    submitAnswers() {
        this.cardsService.postCards(this.answers).then(response => response.subscribe(result => {
            this.router.navigateByUrl(AppRoutes.mainAppCards);
        }, error => console.error(error)));
    }
}
