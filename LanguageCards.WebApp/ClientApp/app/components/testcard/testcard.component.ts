import { Component, Input, OnInit } from '@angular/core';
import { Card } from '../../shared/classes/card';
import { Word } from '../../shared/classes/word';
import { Answer } from '../../shared/classes/answer';

@Component({
    selector: 'testcard',
    templateUrl: './testcard.component.html',
    styleUrls: ['./testcard.component.css'],
})

export class TestCardComponent implements OnInit {
    @Input() card: Card;
    @Input() answer: Answer = new Answer();

    constructor() { }

    ngOnInit() {
        this.answer.cardId = this.card.id;
    }
}