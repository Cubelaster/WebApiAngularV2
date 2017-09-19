import { ModuleWithProviders } from '@angular/core';
import { RouterModule } from '@angular/router';

import { RootComponent } from '../../Components/dashboard/root/root.component';
import { HomeComponent } from '../../Components/dashboard/home/home.component';

import { AuthGuard } from '../../auth.guard';

export const routing: ModuleWithProviders = RouterModule.forChild([
    {
        path: 'dashboard',
        component: RootComponent, canActivate: [AuthGuard],

        children: [
            { path: '', component: HomeComponent },
            { path: 'home', component: HomeComponent },
        ]
    }
]);