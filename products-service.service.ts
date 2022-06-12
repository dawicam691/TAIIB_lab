import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import {PostProductDto} from './models/PostProductDto'
import {ProductDto} from './models/ProductDto'
import {PaginationDto} from './models/PaginationDto'
import {Pagination} from './models/Pagination'
import {PaginatedData} from './models/PaginatedData'
import {Products} from './models/Products'
@Injectable({
  providedIn: 'root'
})
export class ProductsServiceService {

  constructor(private httpClient: HttpClient) { }
  post( id:number,name:string,description:string,price:number):Observable<ProductDto>{
     return this.httpClient.post<ProductDto>('http://localhost:10661/api/Products?page='
     +id,name+','+description+','+price);
  }
  get(pagination?: Pagination): Observable<PaginatedData<Products>>{
    //if(pagination == null)
    return this.httpClient.get<PaginatedData<Products>>('http://localhost:10661/api/Products?page=' 
    + (pagination?.page ?? 1)
    +'&SortColumn=' + (pagination?.sortAscending ?? 10)
    +'&SortAscending=' + (pagination?.sortAscending ?? true)
    +'&SortColumn=' + (pagination?.sortColumn ?? 'name'));
  }
  /*
  put(id:number, product:Products):Observable<Products>{
    return this.httpClient.put<Products>('http://localhost:10661/api/Products?page='
    +id,product);
  }
  */
  delete(id:number): Observable<boolean>{
    return this.httpClient.delete<boolean>('http://localhost:10661/api/Products?page='
    +id);
  }
  getById(id: number): Observable<Products>{
    return this.httpClient.get<Products>('http://localhost:10661/api/Products/'+id); 
    
  }
  put(id: number, dto: PostProductDto): Observable<Products>{
    return this.httpClient.put<Products>('http://localhost:10661/api/Products/'+IdleDeadline,dto);
  }
}
