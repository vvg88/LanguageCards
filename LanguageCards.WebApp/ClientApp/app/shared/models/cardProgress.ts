import Card from './card';
import CardStatus from './cardStatus';

export default class CardProgress {
    id: number;
    score: number;
    maxScore: number;
    cardid: number;
    card: Card;
    cardStatusId: number;
    cardStatus: CardStatus;
}