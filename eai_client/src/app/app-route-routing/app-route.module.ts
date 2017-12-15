import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AppRouteRoutingModule } from './app-route-routing.module';

@NgModule({
    imports: [
        CommonModule,
        AppRouteRoutingModule
    ],
    exports: [
        AppRouteRoutingModule
    ],
    declarations: []
})
export class AppRouteModule { }