module WordModule {
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
    }
}