import { Component, OnInit } from '@angular/core';
import { ProductsServiceService } from 'app/products-service.service';
import { BasketItem } from '../models/basket-Item';
import { Pagination } from '../models/Pagination';
import { Products } from '../models/Products';
//import { ProductServiceService } from '../product-service.service';


/*
@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
*/
@Component({
  selector: 'app-products-list',
  templateUrl: './products-list.component.html',
  styleUrls: ['./products-list.component.css']
})
export class ProductsListComponent {
  page: number=1;
  rowsPerPage=10;
  title = 'lab2zad1';
  producty: Products[]=[];
  basket: BasketItem[]=[];
  products: Products[]=[];
  baskedService: any;
  constructor(private ProductService: ProductsServiceService){
    let pagination = new Pagination();
    pagination.page=0;
    pagination.rowsPerPage=this.rowsPerPage;
    ProductService.get().subscribe(response => this.producty = response.data);
  }
  dodajClick(p:Products):void{
      this.baskedService.post(p.description,1)
  }

  refresh():void{
    let pagination = new Pagination();
    pagination.page=0;
    pagination.rowsPerPage=this.rowsPerPage;
    this.ProductService.get().subscribe(response => this.producty = response.data);
  }

}