import { IUserRegistration } from '../../ContractExports';

export class UserRegistration implements IUserRegistration {
    email: string;
    password: string;
    userName: string;

    constructor() {
        this.email = '';
        this.password = '';
        this.userName = '';
    }
}