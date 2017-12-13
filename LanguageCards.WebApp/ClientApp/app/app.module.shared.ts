import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { RouterModule } from '@angular/router';

import { ROUTES } from './app.routes';
import AppComponent from './components/app/app.component';
import NavMenuComponent from './components/navmenu/navmenu.component';
import SigninComponent from './components/signin/signin.component';
import CardsComponent from './components/cards/cards.component';
import CardComponent from './components/card/card.component';
import MainAppComponent from './components/mainapp/mainapp.component';
import CardDetailComponent from './components/carddetail/carddetail.component';
import TestCardComponent from './components/testcard/testcard.component';
import TestComponent from './components/test/test.component';

import SignInService from './services/signin.service';
import CardsService from './services/cards.service';

@NgModule({
    declarations: [
        AppComponent,
        NavMenuComponent,
        SigninComponent,
        CardComponent,
        CardsComponent,
        MainAppComponent,
        CardDetailComponent,
        TestCardComponent,
        TestComponent,
    ],
    imports: [
        CommonModule,
        HttpModule,
        FormsModule,
        RouterModule.forRoot(ROUTES)
    ],
    providers: [
        SignInService,
        CardsService,
    ],
})
export class AppModuleShared {
}
