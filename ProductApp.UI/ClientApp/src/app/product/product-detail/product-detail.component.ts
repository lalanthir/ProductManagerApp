import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup,  Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Observable } from 'rxjs';
import { Product } from 'src/app/models/Product-create.model';
import { ProductService } from 'src/app/sharedServices/product.service';
@Component({
  selector: 'app-product-detail',
  templateUrl: './product-detail.component.html',
  styleUrls: ['./product-detail.component.scss']
})
export class ProductDetailComponent implements OnInit {
  form: FormGroup;
  public ProductTypeList : any =['Books', 'Food','Toys','Electronics','Furniture'];
  pageTitle ='';
  product: Product;
  errorMessage = '';
  successMessage = '';
  selectedProductId:number = 0;
  constructor(private service: ProductService, 
    private router: Router,
    private route: ActivatedRoute,
    private fb: FormBuilder) { 
    this.form = this.fb.group({
      Name: ['', [Validators.required]],
      Type: ['', [Validators.required]],
      Price: ['', [Validators.required, Validators.min(1)]],     
      Active: [true]
    });
  }

  ngOnInit() {
    this.pageTitle = 'Add Product';
    const param = this.route.snapshot.paramMap.get('id');
    if (param) {
      this.selectedProductId = +param;
      if(this.selectedProductId>0){
        this.pageTitle = 'Edit Product';
        this.getProduct(this.selectedProductId);
      }
     
    }
  }

  getProduct(id: number): void {
    this.service.getProduct(id).subscribe((data:any) =>{
      this.product = data;
      this.SetFormData();
    }     
    );
    
  }

  private _triggerValidationErrors(): void {
    Object.keys(this.form.controls).forEach(field => {
      const control = this.form.get(field);
      control.markAsTouched({ onlySelf: true });
    });
  }

  private SetFormData(){
    this.form.get('Name').setValue(this.product.name);
    this.form.get('Type').setValue(this.product.type);
    this.form.get('Price').setValue(this.product.price);
    this.form.get('Active').setValue(this.product.active);
  }


  private clearformControls() {
    
    this.form.reset();
  }

  public saveProduct():void{
    if (!this.form.valid) {
      this._triggerValidationErrors();
      return;
    }

    if (!this.form.valid) {
      return;
    }
    var self = this;
    const id = this.selectedProductId;
    const productReq: Product = {
      id: id,
      name: this.form.get('Name').value,
      type : this.form.get('Type').value,
      active : this.form.get('Active').value,
      price:  this.form.get('Price').value      
    }
    this.service.saveProduct(productReq)
    .subscribe(
      (data: any) => {
        this.clearformControls();       
        self.successMessage='Product saved Successfully';
        setTimeout(function(){
          self.onBack()
        },1000);
      },
      error => {
        if(error.error !=null){
          self.errorMessage ='Error Occurred : '+ error.error.Message;
        }
        else{
          self.errorMessage ='Error Occurred';
        }
              
      }
      );

  }

  onBack(): void {
    this.router.navigate(['/products']);
  }

}
