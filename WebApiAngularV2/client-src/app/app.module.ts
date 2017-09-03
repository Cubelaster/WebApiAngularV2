﻿import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';

import { AppComponent } from './app.component';
import { AppRoutingModule } from './app-routing/app-routing.module';
import { MainMenuComponent } from '../app/main-menu/main-menu.component';
import { ProductsService } from '../app/services/products.service';


@NgModule({
  declarations: [
      AppComponent,
      MainMenuComponent
  ],
  imports: [
      BrowserModule,
      HttpModule,
      FormsModule,
      AppRoutingModule
  ],
  providers: [
      ProductsService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
