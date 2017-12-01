import { Component, Inject, Input } from '@angular/core';
import { Http } from '@angular/http';
import { Card } from '../../models/card';
import { Word } from '../../models/word';

@Component({
    selector: 'card',
    templateUrl: './card.component.html',
    styleUrls: ['./card.component.css'],
})

export class CardComponent {
    @Input() card: Card;
    public answer: string = "";

    constructor() { }
}
