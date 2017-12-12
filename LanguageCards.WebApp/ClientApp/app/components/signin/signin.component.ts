import { Component, Inject } from '@angular/core';
import { Router } from '@angular/router';
import { Http } from '@angular/http';
import { SignInCredentials } from '../../shared/classes/signInCredentials';
import { SignInService } from '../../services/signin.service';
import { AppRoutes } from '../../shared/classes/routes'

@Component({
    selector: 'signin',
    templateUrl: './signin.component.html',
    styleUrls: ['./signin.component.css'],
})

export class SigninComponent {
    public signInCredentials: SignInCredentials = new SignInCredentials();

    private signInService: SignInService;
    private router: Router;

    constructor(signInService: SignInService,
                router: Router) {
        this.signInService = signInService;
        this.router = router;
    }

    public signIn() {
        this.signInService.signIn(this.signInCredentials).then(response => response.subscribe(result => {
            if (result.ok) {
                this.router.navigateByUrl(AppRoutes.mainAppCards);
            }
        }, error => console.error(error)));
    }
}
