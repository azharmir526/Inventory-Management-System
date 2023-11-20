import { Component, OnInit } from '@angular/core';
import { Products } from '../products';
import { ProductsService } from '../products.service';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-view',
  templateUrl: './view.component.html',
  styleUrls: ['./view.component.css']
})
export class ViewComponent implements OnInit {
  id!: number;
  products!: Products;
  quantitysales: number = 1;
  quantitycheck: number = 0

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
  }

  createSale(){
    if(this.quantitysales == undefined || this.quantitysales == 0)
    {
      return console.error();
      
    }
    else{
      this.productsService.createSale(this.id, this.quantitysales).subscribe((res:any) => {
        this.router.navigateByUrl('products/index');
      })
    }
  }


}
