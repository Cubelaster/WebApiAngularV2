import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpModule, XHRBackend } from '@angular/http';
import { AuthenticateXHRBackend } from './authenticate-xhr.backend';
import { ToastModule } from 'ng2-toastr/ng2-toastr';
import { ToastOptions } from 'ng2-toastr';

import { routing } from './app-routing/app.routing';

import { AppComponent } from './app.component';
import { HeaderComponent, HomeComponent } from './Components/index';
import { AlertComponent } from './Utils/Components/index';

import { AccountModule } from './modules/account/account.module';
import { DashboardModule } from './modules/dashboard/dashboard.module';

import { ConfigService } from './Utils/Services/config.service';
import { AlertService } from '../app/Services/services';
import { CustomToastrOptions } from './Utils/Toastr/CustomToastrOptions';

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
        BrowserAnimationsModule,
        FormsModule,
        HttpModule,
        ToastModule.forRoot(),
        routing
    ],
    providers: [ConfigService, {
        provide: XHRBackend,
        useClass: AuthenticateXHRBackend
    },
        AlertService,
        { provide: ToastOptions, useClass: CustomToastrOptions }
    ],
    bootstrap: [AppComponent]
})
export class AppModule { }
