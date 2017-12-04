import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './components/app/app.component';
import { NavMenuComponent } from './components/navmenu/navmenu.component';
import { SigninComponent } from './components/signin/signin.component';
import { CardsComponent } from './components/cards/cards.component'
import { CardComponent } from './components/card/card.component'
import { Card } from './models/card';
import { Word } from './models/word';

@NgModule({
    declarations: [
        AppComponent,
        NavMenuComponent,
        SigninComponent,
        CardComponent,
        CardsComponent,
    ],
    imports: [
        CommonModule,
        HttpModule,
        FormsModule,
        RouterModule.forRoot([
            { path: '', redirectTo: 'signin', pathMatch: 'full' },
            { path: 'signin', component: SigninComponent },
            { path: 'cards', component: CardsComponent },
            { path: '**', redirectTo: 'signin' }
        ])
    ]
})
export class AppModuleShared {
}
