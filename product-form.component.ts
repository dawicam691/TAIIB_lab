import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { PostProductDto } from '../models/PostProductDto';
import { Products } from '../models/Products';
import { ProductsServiceService } from '../products-service.service';

@Component({
  selector: 'app-product-form',
  templateUrl: './product-form.component.html',
  styleUrls: ['./product-form.component.css']
})
export class ProductFormComponent implements OnInit {

  private productId:number;
  product: Products;
  constructor(private activatedRoute: ActivatedRoute,
    private router: Router,
    private productsService: ProductsServiceService) { }

  ngOnInit(): void {
    this.activatedRoute.params.subscribe(p=>{
      this.productsService.getById(p['id']).subscribe(res=>this.product=res);
    this.productId=p['id'];
    });
  }
/*-
  onSubmit():void{
    console.log(this.product);
  }
*/
  onSubmit(event: NgForm):void{
    //this.productsService.put(this.product.id)
    this.productsService.put(this.productId, event.form.value).subscribe({
      next: res=>{
        console.log(res);
        this.router.navigateByUrl('products');
    },
      error: error=>{
        console.log(error);
    }});
    }
  
}
