import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute, Params } from '@angular/router';
import { Products } from '../../Models/ViewModelExports';
import { ProductsService } from '../../Services/products.service';


@Component({
  selector: 'app-product-detail',
  templateUrl: './product-detail.component.html',
  styleUrls: ['./product-detail.component.css']
})
export class ProductDetailComponent implements OnInit {

  productId: number;
  product: Products;
  constructor(private activatedRoute: ActivatedRoute,
    private productsService: ProductsService) { }

  ngOnInit() {
    this.activatedRoute.params.subscribe(params => {
      this.productId = params['Id'];
      this.product = this.productsService.getProduct(this.productId);
    });
  }

}
