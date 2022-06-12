import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { BasketItem } from './models/basket-item';
import { HttpClient } from '@angular/common/http';

import { PaginatedData } from './models/PaginatedData';
import { Pagination } from './models/Pagination';
@Injectable({
  providedIn: 'root'
})
export class BasketServiceService {

  constructor(private httpClient: HttpClient) { }
  post(productId: number, count: number):Observable<BasketItem[]>{
    return this.httpClient.post<BasketItem[]>('http://localhost:10661/api/Basket'
    +productId, count);
  }
  get(pagination?: Pagination): Observable<PaginatedData<BasketItem>>{
    return this.httpClient.get<PaginatedData<BasketItem>>('http://localhost:10661/api/Basket?page='
    + (pagination?.page ?? 1)
    +'&SortColumn=' + (pagination?.sortAscending ?? 10)
    +'&SortAscending=' + (pagination?.sortAscending ?? true)
    +'&SortColumn=' + (pagination?.sortColumn ?? 'name'));
  }
  put(productId: number, count: number):Observable<BasketItem[]>{
    return this.httpClient.put<BasketItem[]>('http://localhost:10661/api/Basket'
    +productId, count);
  }
  delete(productId: number):Observable<BasketItem[]>{
    return this.httpClient.delete<BasketItem[]>('http://localhost:10661/api/Basket'
    +productId);
  }
  clear(): Observable<boolean>{
    return this.httpClient.delete<boolean>('http://localhost:10661/api/Basket');
  }
}
