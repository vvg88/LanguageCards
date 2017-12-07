import { Component, Input } from '@angular/core';
import { Card } from '../../models/card';
import { Word } from '../../models/word';

@Component({
    selector: 'testcard',
    templateUrl: './testcard.component.html',
    styleUrls: ['./testcard.component.css'],
})

export class TestCardComponent {
    @Input() card: Card;
    public answer: string = "";

    constructor() { }
}