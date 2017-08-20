import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CommonModule } from '@angular/common';

import { ProductListComponent } from '../product-list/product-list.component';

const routes: Routes = [
    {
        path: 'product-list',
        component: ProductListComponent
    }
];

@NgModule({
    imports: [
        CommonModule,
        RouterModule.forRoot(routes)
    ],
    exports: [
        RouterModule
    ],
    declarations: [
        ProductListComponent
    ]
})
export class AppRoutingModule { }
