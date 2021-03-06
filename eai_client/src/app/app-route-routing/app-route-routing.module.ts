import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Routes, RouterModule } from '@angular/router';

import { MainComponent } from '../main/main.component';
import { AppComponent } from '../app.component';
import { ProjectComponent } from '../project/project.component';
import { EquipmentComponent } from '../equipment/equipment.component';
import { EquipmentsListComponent } from '../equipments-list/equipments-list.component';
import { ProjectListComponent } from '../project-list/project-list.component';
import { CreateProjectComponent } from '../create-project/create-project.component';
import { CreateEquipmentComponent } from '../create-equipment/create-equipment.component';
import { ManageGroupsComponent } from '../manage-groups/manage-groups.component';

import { WiringPowerComponent } from '../bilans/wiring-power/wiring-power.component';
import { WiringProtectionComponent } from '../bilans/wiring-protection/wiring-protection.component';
import { ThermalDissipationComponent } from '../bilans/thermal-dissipation/thermal-dissipation.component';
import { CommandProtectionComponent } from '../bilans/command-protection/command-protection.component';
import { MotorStarterComponent } from '../bilans/motor-starter/motor-starter.component';

const routes: Routes = [
  {path:'', component: MainComponent},
  {path:'project', component: ProjectComponent},
  {path:'equipment/:id', component: EquipmentComponent},
  {path:'equipment', component: EquipmentComponent},
  {path: 'createEquipment/:idProject', component: CreateEquipmentComponent},
  {path:'equipmentList/:id', component: EquipmentsListComponent},
  {path:'createProject', component: CreateProjectComponent},
  {path:'manageGroups/:idProject', component: ManageGroupsComponent},

  //Bilans module part
  {path: 'wiringPower/:idProject', component: WiringPowerComponent},
  {path: 'wiringProtection/:idProject', component: WiringProtectionComponent},
  {path: 'thermalDissipation/:idProject', component: ThermalDissipationComponent},
  {path: 'commandProtection/:idProject', component: CommandProtectionComponent},
  {path: 'motorStarter/:idProject', component: MotorStarterComponent}
];

@NgModule({
  imports: [
    CommonModule,
    [RouterModule.forRoot(routes)]
  ],
  exports: [RouterModule],
  declarations: []
})

export class AppRouteRoutingModule { }
