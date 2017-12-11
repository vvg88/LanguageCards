import { Component, Inject, ViewChild } from '@angular/core';
import { Router } from '@angular/router';
import { Http } from '@angular/http';
import { Card } from '../../shared/classes/card';
import { Answer } from '../../shared/classes/answer';
import { TestCardComponent } from '../testcard/testcard.component';

@Component({
    selector: 'test',
    templateUrl: './test.component.html',
    styleUrls: ['./test.component.css'],
})
export class TestComponent {
    public cards: Card[] = [];
    public answers: Answer[] = [{ answerText: "", cardId: 0 }, { answerText: "", cardId: 0 }, { answerText: "", cardId: 0 }, { answerText: "", cardId: 0 }, { answerText: "", cardId: 0 }];
    private http: Http;
    private baseUrl: string;
    private router: Router;

    @ViewChild(TestCardComponent) private tstCardComps: TestCardComponent[] = [];

    constructor(http: Http, @Inject('BASE_URL') baseUrl: string, router: Router) {
        http.get(baseUrl + 'api/cards').subscribe(result => {
            this.cards = result.json() as Card[];
        }, error => console.error(error));
        this.http = http;
        this.baseUrl = baseUrl;
        this.router = router;
    }

    submitAnswers() {
        this.http.post(this.baseUrl + 'api/cards', this.answers).subscribe(result => {
            this.router.navigateByUrl('/mainapp/(cardList:cards)');
        });
    }
}
