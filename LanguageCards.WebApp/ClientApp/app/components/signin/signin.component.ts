import { Component } from '@angular/core';

@Component({
    selector: 'signin',
    templateUrl: './signin.component.html'
})
export class SigninComponent {
    private email: string;
    private password: string;

    public signIn() {
        var i = 0;
        i = 5;
        const e: string = this.email;
        var p = this.password;
    }
}
