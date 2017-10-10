import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

import { IUserRegistration } from '../../Models/index'
import { UserService, AlertService } from '../../Services/services';

@Component({
    selector: 'app-registration-form',
    templateUrl: './registration-form.component.html',
    styleUrls: ['./registration-form.component.css']
})
export class RegistrationFormComponent implements OnInit {

    isRequesting: boolean;
    submitted: boolean = false;

    constructor(private userService: UserService, private alertService: AlertService, private router: Router) {

    }

    ngOnInit() {

    }

    registerUser({ value, valid }: { value: IUserRegistration, valid: boolean }) {
        this.submitted = true;
        this.isRequesting = true;
        if (valid) {
            this.userService.register(value.userName, value.email, value.password, value.passwordConfirmed)
                .finally(() => this.isRequesting = false)
                .subscribe(
                result => {
                    if (result) {
                        this.router.navigate(['/login'], { queryParams: { brandNew: true, email: value.email } });
                    }
                },
                error => this.alertService.error(error, true));
        }
    }
}
