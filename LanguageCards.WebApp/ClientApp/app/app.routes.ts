import { Routes } from '@angular/router';

import SigninComponent from './components/signin/signin.component';
import CardsComponent from './components/cards/cards.component';
import CardComponent from './components/card/card.component';
import MainAppComponent from './components/mainapp/mainapp.component';
import TestComponent from './components/test/test.component';
import StatisticComponent from './components/statistic/statistic.component';

export const ROUTES: Routes = [
    { path: '', redirectTo: 'signin', pathMatch: 'full' },
    { path: 'signin', component: SigninComponent },
    { path: 'mainapp', component: MainAppComponent, children: [
        { path: 'cards', component: CardsComponent, outlet: 'cardList' },
        { path: 'statistic', component: StatisticComponent, outlet: 'cardList' },
        ]
    },
    { path: 'test', component: TestComponent },
    { path: '**', redirectTo: 'signin' }
];