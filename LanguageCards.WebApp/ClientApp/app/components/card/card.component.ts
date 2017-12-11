import { Component, Inject, Input } from '@angular/core';
import { Http } from '@angular/http';
import { Card } from '../../shared/classes/card';
import { Word } from '../../shared/classes/word';

@Component({
    selector: 'card',
    templateUrl: './card.component.html',
    styleUrls: ['./card.component.css'],
})

export class CardComponent {
    @Input() card: Card;

    constructor() { }
}
