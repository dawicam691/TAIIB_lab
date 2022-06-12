import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { ProductComponent } from './product/product.component';
import {HttpClientModule}from '@angular/common/http';
import { BasketListComponent } from './basket-list/basket-list.component';
import { UsersListComponent } from './users-list/users-list.component';
import { ProductsListComponent } from './products-list/products-list.component';
import { RouterModule } from '@angular/router';
import { APP_ROUTES } from './app-routing';
import { FormsModule } from '@angular/forms';
import { ProductFormComponent } from './product-form/product-form.component';
import { ProduktyComponent } from './produkty/produkty.component';
@NgModule({
  declarations: [
    AppComponent,
    ProductComponent,
    BasketListComponent,
    UsersListComponent,
    ProductsListComponent,
    ProductFormComponent,
    ProduktyComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    RouterModule.forRoot(APP_ROUTES),
    FormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
