import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { FormBuilder, FormGroup, FormControl, Validators } from '@angular/forms';

@Component({
  selector: 'app-create-equip-step1',
  templateUrl: './create-equip-step1.component.html',
  styleUrls: ['./create-equip-step1.component.css']
})
export class CreateEquipStep1Component implements OnInit {
  ngOnInit(): void {
    
  }

  @Output() toggleEvent = new EventEmitter();

  formMotoEquip: FormGroup;
  formArea: FormGroup;
  formOpeIn: FormGroup;
  formElecDis: FormGroup;
  formPowerFeat: FormGroup;
  formWiring: FormGroup;
  formThermDiss: FormGroup

  dataEquip: any = [];

  constructor(private fb: FormBuilder) {
    this.formMotoEquip = fb.group({
      idtNumber: '',
      descEquip: 'Initial Desc',
      revision: '',
      SuiviAsm: 'Ajout'
    });

    this.formArea = fb.group({
      pidRef: 'Initial pidRef',
      numZone: 'Initial numZone',
      file: 'Initial file',
      zonePro: 'Initial zonePro',
      atelier: 'Initial atelier',
      sousAtelier: 'Initial sousAtelier',
    });

    this.formOpeIn = fb.group({
      moteurImm: 'true',
      atex: '0',
      package: 'true',
      backupGen: 'true',
      vfd: 'true',
      backupInverter: 'true',
      etat: 'En service',
      packageTyp: 'Initial Package'
    });

    this.formElecDis = fb.group({
      transfo: '',
      tgbtLocation: '',
      mccLocation: '',
      departType: '',
      alimenElec: '',
      intensite: '',
      cosPhi: ''
    });

    this.formPowerFeat = fb.group({
      nominalInstPow: '',
      mechPowDemand: '',
      motorEfficiency: '',
      motorEfficiencyCl: '',
      installAbsorPowDp: '',
      dutyAbsPow: ''
    });

    this.formWiring = fb.group({
      typeCablePuissance: '',
      sectionCable: '',
      nbrCable: '',
      typeProtection: '',
      typeCableProtection: '',
      typeCableCommande: '',
      longueurCable: ''
    });

    this.formThermDiss = fb.group({
      hvac: '',
      heatDissipation: ''
    });
   }

   toggleConfTriger(){
    // this.dataEquip.push(this.formMotoEquip, this.formArea, this.formOpeIn, this.formElecDis, this.formPowerFeat, this.formWiring, this.formThermDiss)
    this.dataEquip['MotorizedEquipment'] = this.formMotoEquip;
    this.dataEquip['Area'] = this. formArea;
    this.dataEquip['OperatingInformation'] = this.formOpeIn;
    this.dataEquip['ElectricalDistribution'] = this.formElecDis;
    this.dataEquip['PowerFeature'] = this.formPowerFeat;
    this.dataEquip['Cable'] = this.formWiring;
    this.dataEquip['ThermalDissipation'] = this. formThermDiss;

    this.toggleEvent.emit(this.dataEquip);
   }
}
