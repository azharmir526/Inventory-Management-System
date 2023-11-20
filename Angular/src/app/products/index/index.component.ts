import { Component, OnInit } from '@angular/core';
import { ProductsService } from '../products.service';
import { Products } from '../products';

@Component({
  selector: 'app-index',
  templateUrl: './index.component.html',
  styleUrls: ['./index.component.css']
})
export class IndexComponent implements OnInit {
  products : Products[] = [];
  constructor(public productsService: ProductsService) { }
  
  ngOnInit(): void {
    this.productsService.getAll().subscribe((data: Products[])=>{
      this.products = data;
    })  
  }

  deleteProduct(id:number){
    this.productsService.delete(id).subscribe(res => {
         this.products = this.products.filter(item => item.Id !== id);
    })
  }


}
