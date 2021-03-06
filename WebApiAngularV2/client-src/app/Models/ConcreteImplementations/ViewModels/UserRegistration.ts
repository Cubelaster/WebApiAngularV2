﻿import { IUserRegistration } from '../../index';

export class UserRegistration implements IUserRegistration {
    email: string;
    password: string;
    passwordConfirmed: string;
    userName: string;

    constructor() {
        this.email = '';
        this.password = '';
        this.passwordConfirmed = '';
        this.userName = '';
    }
}