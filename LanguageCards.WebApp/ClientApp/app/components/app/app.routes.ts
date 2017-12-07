import { Routes } from '@angular/router';

import { SigninComponent } from '../signin/signin.component';
import { CardsComponent } from '../cards/cards.component';
import { CardComponent } from '../card/card.component';
import { MainAppComponent } from '../mainapp/mainapp.component';
import { TestComponent } from '../test/test.component';

export const ROUTES: Routes = [
    { path: '', redirectTo: 'signin', pathMatch: 'full' },
    { path: 'signin', component: SigninComponent },
    { path: 'mainapp', component: MainAppComponent, children: [
        { path: 'cards', component: CardsComponent, outlet: 'cardList' }
        ]
    },
    { path: 'test', component: TestComponent },
    { path: '**', redirectTo: 'signin' }
];