import { Component, Inject } from '@angular/core';
import { Product } from './product';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Router } from '@angular/router';
import { catchError } from 'rxjs/operators';

@Component({
  selector: 'app-create-product-component',
  templateUrl: './create-product.component.html'
})

export class CreateProductComponent {

  constructor(private httpClient: HttpClient, @Inject('BASE_URL') private baseUrl: string, private router: Router) { }

  model = new Product("New Product Name", "New Product Text");

  onSubmit() {

    this.httpClient.post(this.baseUrl + 'api/Product/Create', this.model, {
      headers: new HttpHeaders({ 'Content-Type': 'application/json' })
    }).subscribe(result => {
    }, error => console.error(error));
  
    this.router.navigate(['/products'])
  }
}
