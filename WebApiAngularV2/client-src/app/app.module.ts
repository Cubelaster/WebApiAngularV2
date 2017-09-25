import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpModule, XHRBackend } from '@angular/http';
import { AuthenticateXHRBackend } from './authenticate-xhr.backend';

import { routing } from './app-routing/app.routing';

import { AppComponent } from './app.component';
import { HeaderComponent } from './Components/header/header.component';
import { HomeComponent } from './Components/home/home.component';
import { AlertComponent } from './Components/alert/alert.component';

import { AccountModule } from './modules/account/account.module';
import { DashboardModule } from './modules/dashboard/dashboard.module';

import { ConfigService } from '../app/Utils/config.service';
import { AlertService } from '../app/Services/services';

@NgModule({
    declarations: [
        AppComponent,
        AlertComponent,
        HeaderComponent,
        HomeComponent
    ],
    imports: [
        AccountModule,
        DashboardModule,
        BrowserModule,
        FormsModule,
        HttpModule,
        routing
    ],
    providers: [ConfigService, {
        provide: XHRBackend,
        useClass: AuthenticateXHRBackend
    },
        AlertService
    ],
    bootstrap: [AppComponent]
})
export class AppModule { }
