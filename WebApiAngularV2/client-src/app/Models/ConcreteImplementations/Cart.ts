import { Products } from '../ViewModelExports';

export class Cart {
    selectedProducts: Products[] = [];

    addProduct = (product: Products) => {
        product.Quantity = 1;
        this.selectedProducts.push(product);
        console.log('Added');
    }
}