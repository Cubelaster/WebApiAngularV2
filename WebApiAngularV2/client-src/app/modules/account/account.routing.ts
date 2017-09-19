import { ModuleWithProviders } from '@angular/core';
import { RouterModule } from '@angular/router';

import { RegistrationFormComponent } from '../../Components/registration-form/registration-form.component';
import { LoginFormComponent } from '../../Components/login-form/login-form.component';

export const routing: ModuleWithProviders = RouterModule.forChild([
    { path: 'register', component: RegistrationFormComponent },
    { path: 'login', component: LoginFormComponent }
]);