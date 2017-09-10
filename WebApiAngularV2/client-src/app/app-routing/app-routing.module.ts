import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CommonModule } from '@angular/common';

import { ProductListComponent } from '../product-list/product-list.component';
import { ProductDetailComponent } from '../product-detail/product-detail.component';

const routes: Routes = [
    {
        path: 'product-list',
        component: ProductListComponent
    },
    {
        path:'product/:Id',
        component: ProductDetailComponent
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
