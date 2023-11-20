import { Component, OnInit } from '@angular/core';
import { Products } from '../products';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ProductsService } from '../products.service';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-edit',
  templateUrl: './edit.component.html',
  styleUrls: ['./edit.component.css']
})
export class EditComponent implements OnInit{
  id!: number;
  products!: Products;
  form!: FormGroup;

  constructor(
    public productsService: ProductsService,
    private route: ActivatedRoute,
    private router: Router
  ) { }
    

  ngOnInit(): void {
    this.id = this.route.snapshot.params['prodId'];
    this.productsService.find(this.id).subscribe((data: Products)=>{
      this.products = data;
    }); 
    
    this.form = new FormGroup({
      Name: new FormControl('', [Validators.required]),
      Description: new FormControl('', Validators.required),
      Quantity: new FormControl('', Validators.required)
    });
  }


  get f(){
    return this.form.controls;
  }


  submit(){
    this.productsService.update(this.id, this.form.value).subscribe((res:any) => {
         this.router.navigateByUrl('products/index');
    })
  }

}
