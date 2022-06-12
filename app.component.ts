import { Component } from '@angular/core';
import { Products } from './models/Products';
//import { Products } from './models/Products';
//import { ProductServiceService } from './product-service.service';
//import { BasketItem } from './models/basket-Item';
@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  
  producty: Products[];

}
