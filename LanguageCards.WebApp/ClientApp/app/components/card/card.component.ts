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
    @Input() cardItem: Card = {
        id: 1,
        word: {
            id: 1,
            text: "creation",
            definition: "The act of creating something, or the thing that is created",
            example: "The creation of a new political party.",
            languageId: 1,
            language: {
                id: 1,
                name: "English (United States)",
            },
            speechPartId: 1,
            speechPart: {
                id: 1,
                name: "Noun",
            },
            translations: [
                {
                    id: 13,
                    text: "Творчество",
                    definition: "",
                    example: "",
                    languageId: 2,
                    language: {
                        id: 2,
                        name: "Russian",
                    },
                    speechPartId: 1,
                    speechPart: {
                        id: 1,
                        name: "Noun",
                    },
                    translations: [],
                },
                {
                    id: 15,
                    text: "Созидание",
                    definition: "",
                    example: "",
                    languageId: 2,
                    language: {
                        id: 2,
                        name: "Russian",
                    },
                    speechPartId: 1,
                    speechPart: {
                        id: 1,
                        name: "Noun",
                    },
                    translations: [],
                },
                {
                    id: 19,
                    text: "Создание",
                    definition: "",
                    example: "",
                    languageId: 2,
                    language: {
                        id: 2,
                        name: "Russian",
                    },
                    speechPartId: 1,
                    speechPart: {
                        id: 1,
                        name: "Noun",
                    },
                    translations: [],
                }
            ],
        },
    };
    public answer: string = "";

    constructor() { }
}
