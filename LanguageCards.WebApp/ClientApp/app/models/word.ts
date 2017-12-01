export class Word {
    id: number;
    text: string;
    languageId: number;
    language: {
        id: number;
        name: string;
    }
    speechPartId: number;
    speechPart: {
        id: number;
        name: string;
    }
    definition: string;
    translations: Word[];
    example: string;

    constructor(obj: any) {
        this.id = obj.id;
        this.text = obj.text;
        this.languageId = obj.languageId;
        this.language.id = obj.language.id;
        this.language.name = obj.language.name;
        this.speechPartId = obj.speechPartId;
        this.speechPart.id = obj.speechPart.id;
        this.speechPart.name = obj.speechPart.name;
        this.definition = obj.definition;
        this.translations = obj.translations;
        this.example = obj.example;
    }
}
