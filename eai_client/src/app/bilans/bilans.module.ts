import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { WiringPowerComponent } from './wiring-power/wiring-power.component';
import { WiringProtectionComponent } from './wiring-protection/wiring-protection.component';
import { ThermalDissipationComponent } from './thermal-dissipation/thermal-dissipation.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { CommandProtectionComponent } from './command-protection/command-protection.component';
import { MotorStarterComponent } from './motor-starter/motor-starter.component';

@NgModule({
  imports: [
    CommonModule,
    FormsModule, 
    ReactiveFormsModule
  ],
  declarations: [WiringPowerComponent, WiringProtectionComponent, ThermalDissipationComponent, CommandProtectionComponent, MotorStarterComponent]
})
export class BilansModule { }
