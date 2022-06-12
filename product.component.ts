import { Component, Input, OnInit, Output } from '@angular/core';
import { Products } from '../models/Products';
import { ActivatedRoute, Router } from '@angular/router';
import { ProductsServiceService } from 'app/products-service.service';
//import { ProductServiceService } from 'app/product-service.service';

@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.css']
})
export class ProductComponent implements OnInit {
  @Input() data: Products[];
  @Input('basket') basket: Products[];
  @Input('products') products: Products[];
  constructor(
    private nazwa: ProductsServiceService,
    private router:Router
  ) { 

    

  }

  ngOnInit(): void {
  }
  koszykLicznik:number=0;
  
  dodajProdukt(p:Products):void{
    this.basket.push(p);
    this.koszykLicznik++;
  }


  edytujClick(product: Products):void{
      this.router.navigateByUrl('products/'+product.id);
  }

  usun(product: Products):void{
    this.nazwa.delete(product.id);//<---nie tak
  }
}
