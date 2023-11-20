import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, catchError, throwError } from 'rxjs';
import { Products } from './products';
import { environment } from '../environment';

@Injectable({
  providedIn: 'root'
})
export class ProductsService {
  
  private apiURL = environment.baseUrl;
  //private apiURL = "http://localhost:15489/";
  
  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json'
    })
  }

  constructor(private httpClient: HttpClient) { }

  getAll(): Observable<any> {
    return this.httpClient.get(this.apiURL + 'Products')
    .pipe(
      catchError(this.errorHandler)
    )
  }

  delete(id:number){
    return this.httpClient.delete(this.apiURL + 'Products?id=' + id, this.httpOptions)
    .pipe(
      catchError(this.errorHandler)
    )
  }

  find(id:number): Observable<any> {
    return this.httpClient.get(this.apiURL + 'Products/GetById?id=' + id)
    .pipe(
      catchError(this.errorHandler)
    )
  }

  create(products:Products): Observable<any> {
    return this.httpClient.post(this.apiURL + 'Products', JSON.stringify(products), this.httpOptions)
    .pipe(
      catchError(this.errorHandler)
    )
  }  

  update(id:number, products:Products): Observable<any> {
    return this.httpClient.put(this.apiURL + 'Products?id=' + id, JSON.stringify(products), this.httpOptions)
    .pipe( 
      catchError(this.errorHandler)
    )
  }

  createSale(id:number, quantity:number): Observable<any> {
    const url = this.apiURL + 'Sales?id=' +id + '&quantity='+quantity;
    return this.httpClient.post(url, this.httpOptions)
      .pipe(
        catchError(this.errorHandler)
      )
  }


  errorHandler(error:any) {
    let errorMessage = '';
    if(error.error instanceof ErrorEvent) {
      errorMessage = error.error.message;
    } else {
      errorMessage = `Error Code: ${error.status}\nMessage: ${error.message}`;
    }
    return throwError(errorMessage);
   }
}
