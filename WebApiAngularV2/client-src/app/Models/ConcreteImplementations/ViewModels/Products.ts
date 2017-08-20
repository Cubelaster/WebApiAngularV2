import { IProducts } from '../../ContractExports';

export class Products implements IProducts {
    Id?: number;
    Name: string;
    SKU: number;
}