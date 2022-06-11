import { Component, OnDestroy, OnInit } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { Product } from 'src/app/models/Product-create.model';
import { ProductService } from 'src/app/sharedServices/product.service';

@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.scss']
})
export class ProductComponent implements OnInit,OnDestroy {
  products: Product[] = [];
  errorMessage = '';
  pageTitle ="Available Products";
  constructor(private service: ProductService
    ) { }
 
 
  ngOnDestroy() {
    
  }

  ngOnInit() {
    this.initData();
  }

  initData() {
    this.service.getProductList().subscribe((data: any) => {
      this.products = [...data];
     
    });
   
        
  }

}
