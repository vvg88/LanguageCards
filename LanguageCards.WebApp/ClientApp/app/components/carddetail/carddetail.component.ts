import { Component, Input } from '@angular/core';
import { Card } from '../../models/card';
import { Word } from '../../models/word';

@Component({
    selector: 'carddetail',
    templateUrl: './carddetail.component.html',
    //styleUrls: ['./carddetail.component.css'],
})

export class CardDetailComponent {
    @Input() card: Card;

    constructor() { }
}