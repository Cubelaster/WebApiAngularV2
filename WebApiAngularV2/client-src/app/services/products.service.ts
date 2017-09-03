import { Injectable } from '@angular/core';
import { Products } from '../Models/ViewModelExports';

@Injectable()
export class ProductsService {

    constructor() { }

    selectedProducts: Products[] = [];
    getProducts(): Products[] {
        return productsList;
    }
    getSelectedProducts(): Products[] {
        return this.selectedProducts;
    }

    addProduct(Id: number): void {
        let Product = productsList.find(item => item.Id === Id);
        if (this.selectedProducts.indexOf(Product) < 0) {
            this.selectedProducts.push(Product);
        }
    }

    removeProduct(Id: number): void {
        let item = this.selectedProducts.find(ob => ob.Id === Id);
        let itemIndex = this.selectedProducts.indexOf(item);
        this.selectedProducts.splice(itemIndex, 1);
    }

}

export const productsList: Products[] = [
    new Products(7, "Product 7", 22, 7),
    new Products(1, "Product 1", 11, 1),
    new Products(7, "Product 7", 22, 2),
    new Products(7, "Product 7", 22, 3),
    new Products(7, "Product 7", 22, 4)
]; 