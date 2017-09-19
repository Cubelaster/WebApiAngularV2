import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { UtilModule } from '../../Utils/util.module';

import { routing } from './dashboard.routing';
import { RootComponent } from '../../Components/dashboard/root/root.component';
import { HomeComponent } from '../../Components/dashboard/home/home.component';
import { DashboardService } from '../../Services/services';

import { AuthGuard } from '../../auth.guard';

@NgModule({
    imports: [
        CommonModule,
        FormsModule,
        routing,
        UtilModule],
    declarations: [RootComponent, HomeComponent],
    exports: [],
    providers: [AuthGuard, DashboardService]
})
export class DashboardModule { }