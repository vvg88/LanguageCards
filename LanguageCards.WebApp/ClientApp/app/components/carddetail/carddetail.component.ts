import { Component, Input } from '@angular/core';
import { Card } from '../../shared/classes/card';
import { Word } from '../../shared/classes/word';

@Component({
    selector: 'carddetail',
    templateUrl: './carddetail.component.html',
})

export class CardDetailComponent {
    @Input() card: Card;

    constructor() { }
}