import { Component, Input, OnInit } from '@angular/core';
import { Card } from '../../models/card';
import { Word } from '../../models/word';
import { Answer } from '../../models/answer';

@Component({
    selector: 'testcard',
    templateUrl: './testcard.component.html',
    styleUrls: ['./testcard.component.css'],
})

export class TestCardComponent implements OnInit {
    @Input() card: Card;
    @Input() answer: Answer = {
        answerText: "",
        cardId: NaN,
    };

    constructor() { }

    ngOnInit() {
        this.answer.cardId = this.card.id;
    }
}