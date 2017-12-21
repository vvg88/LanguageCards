import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
    selector: 'mainapp',
    templateUrl: './mainapp.component.html',
})
export default class MainAppComponent {
    constructor(router: Router) {
        let accessTok = localStorage['access_token'];
        if (accessTok === undefined) {
            accessTok = sessionStorage['access_token'];
            if (accessTok === undefined) {
                router.navigateByUrl('/signin');
            }
        } else {
            sessionStorage.removeItem('access_token');
            sessionStorage['access_token'] = localStorage['access_token'];
        }
    }
}