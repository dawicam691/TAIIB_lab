import { Routes } from "@angular/router";
import { BasketListComponent } from "./basket-list/basket-list.component";
import { ProductFormComponent } from "./product-form/product-form.component";
//import { ProductComponent } from "./product/product.component";
import { ProductsListComponent } from "./products-list/products-list.component";
import { UsersListComponent } from "./users-list/users-list.component";

export const APP_ROUTES: Routes=[
    {path: 'products', component: ProductsListComponent},
    {path: 'products/:id', component: ProductFormComponent},
    {path: 'basket', component: BasketListComponent},
    {path: 'users', component: UsersListComponent},
    //{path:'products/{id}', component: ProductComponent},
    {path: '', redirectTo: 'products', pathMatch: 'full'}
];