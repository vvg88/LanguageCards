import CardProgress from './cardProgress';

export default class Statistic {
    id: number;
    cardProgressId: number;
    cardProgress: CardProgress;
    attemptsNum: number;
    successfulAttemptsNum: number;
    beginTime: Date;
    finishTime: Date;
}