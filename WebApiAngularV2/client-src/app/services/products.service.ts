import { Injectable } from '@angular/core';
import { Products } from '../Models/ViewModelExports';

@Injectable()
export class ProductsService {

    constructor() { }

    selectedProducts: Products[] = [];
    getProducts(): Products[] {
        return productsList;
    }

    getProduct(Id: number) {
        return productsList.find(item => item.Id == Id);
    }

    getSelectedProducts(): Products[] {
        return this.selectedProducts;
    }

    addProduct(product: Products, quantityToAdd: number): void {
        quantityToAdd = (quantityToAdd <= 0 ? 1 : quantityToAdd)
        let Product = productsList.find(item => item.Id === product.Id);
        if (this.selectedProducts.indexOf(Product) < 0) {
            Product.Quantity = quantityToAdd;
            this.selectedProducts.push(Product);
        } else {
        product.Quantity += quantityToAdd;
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
    new Products(2, "Product 2", 22, 2),
    new Products(3, "Product 3", 22, 3),
    new Products(4, "Product 4", 22, 4)
]; 