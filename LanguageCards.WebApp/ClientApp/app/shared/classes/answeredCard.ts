export class AnsweredCard {
    cardId: number;
    wordDefinition: string;
    speechPart: string;
    translations: string[];
    answer: string;

    constructor(cardId: number, wordDef: string, speechPart: string, tranlations: string[]) {
        this.cardId = cardId;
        this.wordDefinition = wordDef;
        this.speechPart = speechPart;
        this.translations = tranlations;
        this.answer = "";
    }
}