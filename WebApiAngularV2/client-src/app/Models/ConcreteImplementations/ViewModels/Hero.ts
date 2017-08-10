import { IDatabaseEntity } from '../../ContractExports';

export class Hero implements IDatabaseEntity {
    Id?: number;
    DateCreated: Date;
    CreatedBy: number;
    DateChanged?: Date;
    ChangedBy?: number;
    IsChanged?: boolean;
    IsNew?: boolean;

    Name?: string;

    constructor(Name: string) {
        this.Name = Name;
        this.DateCreated = new Date();
        this.CreatedBy = 1;
        this.IsNew = true;
    }

    MarkUpdateDateAndUser(): void {
        this.DateChanged = new Date();
        this.ChangedBy = 1;
        this.IsChanged = true;
    }
}