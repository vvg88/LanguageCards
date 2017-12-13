import { Component, Inject, Input } from '@angular/core';
import { Http } from '@angular/http';
import Card from '../../shared/models/card';
import Word from '../../shared/models/word';

@Component({
    selector: 'card',
    templateUrl: './card.component.html',
    styleUrls: ['./card.component.css'],
})
export default class CardComponent {
    @Input() card: Card;
}
