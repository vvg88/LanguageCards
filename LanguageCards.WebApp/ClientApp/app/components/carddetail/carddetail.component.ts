import { Component, Input } from '@angular/core';
import Card from '../../shared/models/card';
import Word from '../../shared/models/word';

@Component({
    selector: 'carddetail',
    templateUrl: './carddetail.component.html',
})
export default class CardDetailComponent {
    @Input() card: Card;
}