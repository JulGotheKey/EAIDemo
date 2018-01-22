import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpModule } from '@angular/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { AppComponent } from './app.component';
import { MainComponent } from './main/main.component';
import { AppRouteModule } from './app-route-routing/app-route.module';
import { SidebarModule } from 'ng-sidebar';
import { SidebarComponent } from './sidebar/sidebar.component';
import { NavbarComponent } from './share/navbar/navbar.component';
import { ProjectComponent } from './project/project.component';


import { ModalModule } from 'ngx-bootstrap';
import { EquipmentComponent } from './equipment/equipment.component';
import { EquipmentsListComponent } from './equipments-list/equipments-list.component';
import { ProjectListComponent } from './project-list/project-list.component';
import { CreateProjectComponent } from './create-project/create-project.component';
import { CreateEquipmentComponent } from './create-equipment/create-equipment.component';
import { CreateEquipStep1Component } from './create-equip-step1/create-equip-step1.component';
import { CreateEquipStep2Component } from './create-equip-step2/create-equip-step2.component';
import { ManageGroupsComponent } from './manage-groups/manage-groups.component';

import { TreeModule } from 'angular-tree-component';

import { BilansModule } from "./bilans/bilans.module";


@NgModule({
  declarations: [
    AppComponent,
    MainComponent,
    SidebarComponent,
    NavbarComponent,
    ProjectComponent,
    EquipmentComponent,
    EquipmentsListComponent,
    ProjectListComponent,
    CreateProjectComponent,
    CreateEquipmentComponent,
    CreateEquipStep1Component,
    CreateEquipStep2Component,
    ManageGroupsComponent
  ],
  imports: [
    AppRouteModule,
    BrowserModule,
    SidebarModule.forRoot(),
    ReactiveFormsModule,
    ModalModule.forRoot(),
    HttpModule,
    FormsModule,
    TreeModule,
    BilansModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
