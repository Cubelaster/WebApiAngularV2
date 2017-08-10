export interface IDatabaseEntity {
    Id?: number;
    DateCreated: Date;
    CreatedBy: number;
    DateChanged?: Date;
    ChangedBy?: number;
    IsChanged?: boolean;
    IsNew?: boolean;

    // TODO add ApplicationUser
    MarkUpdateDateAndUser(date: Date): void;
}