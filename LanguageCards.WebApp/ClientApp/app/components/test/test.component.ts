import { Component, Inject } from '@angular/core';
import { Http } from '@angular/http';
import { Card } from '../../models/card';

@Component({
    selector: 'test',
    templateUrl: './test.component.html',
    styleUrls: ['./test.component.css'],
})
export class TestComponent {
    public cards: Card[] = [];
    private http: Http;
    private baseUrl: string;

    constructor(http: Http, @Inject('BASE_URL') baseUrl: string) {
        http.get(baseUrl + 'api/cards').subscribe(result => {
            this.cards = result.json() as Card[];
        }, error => console.error(error));
        this.http = http;
        this.baseUrl = baseUrl;
    }

    submitAnswers() {

    }
}