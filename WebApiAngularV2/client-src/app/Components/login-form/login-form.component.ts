import { Subscription } from 'rxjs';
import { Component, OnInit, OnDestroy } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';

import { UserRegistration } from '../../Models/ViewModelExports';
import { UserService } from '../../Services/services';
import { AlertService } from '../../Services/services';

@Component({
    selector: 'app-login-form',
    templateUrl: './login-form.component.html',
    styleUrls: ['./login-form.component.css']
})
export class LoginFormComponent implements OnInit, OnDestroy {

    private subscription: Subscription;

    brandNew: boolean;
    errors: string;
    isRequesting: boolean;
    submitted: boolean = false;
    credentials: UserRegistration = { email: '', password: '', userName: '', passwordConfirmed: '' };

    constructor(private userService: UserService, private alertService: AlertService, private router: Router, private activatedRoute: ActivatedRoute) { }

    ngOnInit() {

        // subscribe to router event
        this.subscription = this.activatedRoute.queryParams.subscribe(
            (param: any) => {
                this.brandNew = param['brandNew'];
                this.credentials.email = param['email'];
            });
    }

    ngOnDestroy() {
        // prevent memory leak by unsubscribing
        this.subscription.unsubscribe();
    }

    login({ value, valid }: { value: UserRegistration, valid: boolean }) {
        this.submitted = true;
        this.isRequesting = true;
        this.errors = '';
        if (valid) {
            this.userService.login(value.userName, value.password)
                .finally(() => this.isRequesting = false)
                .subscribe(
                result => {
                    if (result) {
                        this.router.navigate(['/dashboard/home']);
                    }
                },
                error => this.alertService.error(error, true));
        }
    }
}