import { IProducts } from '../../ContractExports';

export class Products implements IProducts {
    Id?: number;
    Name: string;
    SKU: number;
    Quantity?: number;

    constructor(Id: number, Name: string, SKU: number) {
      this.Id = Id,
      this.Name = Name,
      this.SKU = SKU
    }
}