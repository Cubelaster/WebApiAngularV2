import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';

import { AppComponent } from './app.component';
import { AppRoutingModule } from './app-routing/app-routing.module';
import { MainMenuComponent } from '../app/main-menu/main-menu.component';
import { ProductsService } from '../app/services/products.service';
import { ProductDetailComponent } from './product-detail/product-detail.component';


@NgModule({
  declarations: [
      AppComponent,
      MainMenuComponent,
      ProductDetailComponent
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
