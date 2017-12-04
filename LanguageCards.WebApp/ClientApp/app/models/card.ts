import { Word } from './word';

export class Card {
    id: number;
    word: Word;

    constructor(obj: any) {
        this.id = obj.id;
        this.word = obj.word;
    }
}
