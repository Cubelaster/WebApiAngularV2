import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { UtilModule } from '../../Utils/util.module';

import { UserService } from '../../Services/services';

import { EmailValidator } from '../../Directives/email.validator.directive';

import { routing } from './account.routing';
import { RegistrationFormComponent } from '../../Components/registration-form/registration-form.component';
import { LoginFormComponent } from '../../Components/login-form/login-form.component';

@NgModule({
    imports: [
        CommonModule, FormsModule, routing, UtilModule
    ],
    declarations: [RegistrationFormComponent, EmailValidator, LoginFormComponent],
    providers: [UserService]
})
export class AccountModule { }