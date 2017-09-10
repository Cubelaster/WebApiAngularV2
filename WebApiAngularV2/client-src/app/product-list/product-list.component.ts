import { Component, OnInit } from '@angular/core';
import { Http } from '@angular/http';
import { Products } from '../Models/ViewModelExports';
import { Cart } from '../Models/ViewModelExports';
import { ProductsService } from '../services/products.service';

@Component({
    selector: 'app-product-list',
    templateUrl: './product-list.component.html',
    styleUrls: ['./product-list.component.css']
})
export class ProductListComponent implements OnInit {
    storeProducts: Products[] = [];
    selectedProducts: Products[] = [];
    constructor(private _httpService: Http,
        private productService: ProductsService
    ) { }

    getStoreProducts(): void
    {
        this.storeProducts = this.productService.getProducts();
    }

    getSelectedProducts() : void {
        this.selectedProducts = this.productService.getSelectedProducts();
    }

    Cart = new Cart();

    ngOnInit() {
        this.getStoreProducts();
    }

    addProductToCart(product: Products, quantityToAdd: number): void {
        this.productService.addProduct(product, Number(quantityToAdd));
        this.getSelectedProducts();
    }

}
