import { Component, Input } from '@angular/core';
import Card from '../../shared/models/card';
import Word from '../../shared/models/word';
import Answer from '../../shared/models/answer';
import AnsweredCard from '../../shared/models/answeredCard';

@Component({
    selector: 'testcard',
    templateUrl: './testcard.component.html',
    styleUrls: ['./testcard.component.css'],
})

export default class TestCardComponent {
    @Input() answeredCard: AnsweredCard;
}