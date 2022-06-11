import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Product } from '../models/Product-create.model';

@Injectable({
  providedIn: 'root'
})
export class ProductService {
  private APIURL = 'http://localhost:5000/';

  constructor(private http: HttpClient) { }

  getProductList(): Observable<any[]> {
    return this.http.get<any>(this.APIURL + `api/products`);
  }

  getProduct(id: number): Observable<Product | undefined> {
    return this.http.get<any>(this.APIURL + `api/products/`+id);
  }

}
