import { Component, OnInit } from '@angular/core';
import { Http } from '@angular/http';
import { Products } from '../Models/ViewModelExports';
import { Cart } from '../Models/ViewModelExports';

@Component({
    selector: 'app-product-list',
    templateUrl: './product-list.component.html',
    styleUrls: ['./product-list.component.css']
})
export class ProductListComponent implements OnInit {
    constructor(private _httpService: Http) { }

    productList: Products[] = [
        new Products(1, "Prvi", 1),
        new Products(2, "Drugi", 2),
        new Products(3, "Treci", 3),
        new Products(4, "Četvrti", 4)
    ];

    Cart = new Cart();

    ngOnInit() {
    }

}
