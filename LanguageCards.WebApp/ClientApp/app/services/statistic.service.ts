import { Inject, Injectable } from '@angular/core';
import { Http } from '@angular/http';
import HttpHelper from '../utils/httpHelper';
import Statistic from '../shared/models/statistic';

@Injectable()
export default class StatisticService extends HttpHelper {
    private statApiUrl: string = 'api/cards/statistic';

    constructor(http: Http) {
        super(http);
        this.statApiUrl = this.baseUrl + this.statApiUrl;
    }

    public async getStatistic(): Promise<Statistic[]> {
        let resp = await this.getAction(this.statApiUrl);
        return await new Promise<Statistic[]>((resolve, reject) => resp.subscribe(reslt => {
            let s = reslt.json() as Statistic[];
            resolve(s);
        }, error => reject(error)));
    }
}