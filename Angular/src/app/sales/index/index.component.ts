import { Component, OnInit } from '@angular/core';
import { Sales } from '../sales';
import { SalesService } from '../sales.service';

@Component({
  selector: 'app-index',
  templateUrl: './index.component.html',
  styleUrls: ['./index.component.css']
})
export class IndexComponent implements OnInit {
  sales : Sales[] = [];
  constructor(public salessService: SalesService) { }
  
  ngOnInit(): void {
    this.salessService.getAll().subscribe((data: Sales[])=>{
      this.sales = data;
    })  
  }
  
  deleteSale(id:number){
    this.salessService.delete(id).subscribe(res => {
         this.sales = this.sales.filter(item => item.Id !== id);
    })
  }
}
