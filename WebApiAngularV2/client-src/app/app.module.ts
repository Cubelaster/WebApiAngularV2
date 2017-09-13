
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';

import { AppComponent } from './app.component';
import { AppRoutingModule } from './app-routing/app-routing.module';
import { MainMenuComponent } from '../app/main-menu/main-menu.component';
import { ProductsService } from '../app/Services/products.service';
import { ProductDetailComponent } from './Components/product-detail/product-detail.component';
import { AlertComponent } from './Components/alert/alert.component';


@NgModule({
  declarations: [
      AppComponent,
      MainMenuComponent,
      ProductDetailComponent,
      AlertComponent
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
