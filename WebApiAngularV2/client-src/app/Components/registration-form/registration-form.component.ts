﻿import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

import { IUserRegistration } from '../../Models/ContractExports'
import { UserService } from '../../Services/services';

@Component({
    selector: 'app-registration-form',
    templateUrl: './registration-form.component.html',
    styleUrls: ['./registration-form.component.css']
})
export class RegistrationFormComponent implements OnInit {

    errors: string;
    isRequesting: boolean;
    submitted: boolean = false;

    constructor(private userService: UserService, private router: Router) {

    }

    ngOnInit() {

    }

    registerUser({ value, valid }: { value: IUserRegistration, valid: boolean }) {
        this.submitted = true;
        this.isRequesting = true;
        this.errors = '';
        if (valid) {
            this.userService.register(value)
                .finally(() => this.isRequesting = false)
                .subscribe(
                result => {
                    if (result) {
                        this.router.navigate(['/login'], { queryParams: { brandNew: true, email: value.email } });
                    }
                },
                errors => this.errors = errors);
        }
    }
}