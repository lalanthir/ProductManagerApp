import { Component, OnDestroy, OnInit } from '@angular/core';
import { Router } from '@angular/router';
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
  successMessage = '';
  public booleanValue: boolean = false;
  pageTitle ="Available Products";
  constructor(private service: ProductService,  private router: Router,
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
  public onAddProduct():void{
    this.router.navigate(['/productdetails',0]);
  }
  
  public deleteProduct(id: number, name: string):void{
      console.log('Deleting ID '+ id);

      if (confirm("Are you sure you want to delete product : "+name) == true) {
        this.processDelete(id);
      } 
  }

  private processDelete(id: number){
    var self = this;
    this.service.deleteProduct(id)
    .subscribe(
      () => {
        this.initData();
       
        self.successMessage= 'Product deleted Successfully';
      },
      error => {
        if(error.error !=null){
          self.errorMessage= error.error.Message;  
        }
        else{
          self.errorMessage ='Error Occurred';  
        }
              
      }
      );
  }

  public sort(colName, boolean) {
    if (boolean == true){
        this.products.sort((a, b) => a[colName] < b[colName] ? 1 : a[colName] > b[colName] ? -1 : 0)
        this.booleanValue = !this.booleanValue
    }
    else{
        this.products.sort((a, b) => a[colName] > b[colName] ? 1 : a[colName] < b[colName] ? -1 : 0)
        this.booleanValue = !this.booleanValue
    }
}

}
