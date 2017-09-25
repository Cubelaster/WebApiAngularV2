import { ModuleWithProviders } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { HomeComponent } from '../Components/index';

const appRoutes: Routes = [
    { path: '', component: HomeComponent },
    { path: 'account', loadChildren: 'app/modules/account/account.module#AccountModule' }
];

export const routing: ModuleWithProviders = RouterModule.forRoot(appRoutes);