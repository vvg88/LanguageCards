import { Component } from '@angular/core';
import Statistic from '../../shared/models/statistic';
import StatisticService from '../../services/statistic.service';
import { CardStatusEnum } from '../../shared/enums/cardStatusEnum'

@Component({
    selector: 'statistic',
    templateUrl: './statistic.component.html'
})
export default class StatisticComponent {
    cardStatInProgress: Statistic[] = [];
    cardStatFinished: Statistic[] = [];
    
    constructor(statService: StatisticService) {
        this.getStatistic(statService);
    }

    private getStatistic(statService: StatisticService): void {
        statService.getStatistic().then(statistic => {
            this.cardStatInProgress = statistic.filter(s => s.cardProgress.cardStatusId == CardStatusEnum.InProgress);
            this.cardStatFinished = statistic.filter(s => s.cardProgress.cardStatusId == CardStatusEnum.Finished);
        }).catch(error => console.error(error));
    }
}