import { Component, Input, OnInit } from '@angular/core';
import { Card } from '../../shared/classes/card';
import { Word } from '../../shared/classes/word';
import { Answer } from '../../shared/classes/answer';
import { AnsweredCard } from '../../shared/classes/answeredCard';

@Component({
    selector: 'testcard',
    templateUrl: './testcard.component.html',
    styleUrls: ['./testcard.component.css'],
})

export class TestCardComponent implements OnInit {
    @Input() answeredCard: AnsweredCard;

    constructor() { }

    ngOnInit() { }
}