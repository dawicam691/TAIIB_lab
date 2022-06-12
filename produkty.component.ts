import { Component, OnInit } from '@angular/core';
import { BasketItem } from 'app/models/basket-Item';
import { Pagination } from 'app/models/Pagination';
import { Products } from 'app/models/Products';
import { ProductsServiceService } from 'app/products-service.service';

@Component({
  selector: 'app-produkty',
  templateUrl: './produkty.component.html',
  styleUrls: ['./produkty.component.css']
})
export class ProduktyComponent {
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
