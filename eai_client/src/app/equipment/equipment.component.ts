import { Component, OnInit, OnDestroy } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { EquipmentsService } from '../services/equipments/equipments.service';
import { GroupsService } from '../services/groups/groups.service';
import { FormBuilder, FormGroup, FormControl, Validators } from '@angular/forms';

@Component({
  selector: 'app-equipment',
  templateUrl: './equipment.component.html',
  styleUrls: ['./equipment.component.css'],
  providers: [EquipmentsService, GroupsService]
})
export class EquipmentComponent implements OnInit, OnDestroy {


  idEquipmentSelect: number;
  private sub: any;
  equipmentData: any = [];
  equipGroupName: any;

  formMotoEquip: FormGroup;
  formArea: FormGroup;
  formOpeIn: FormGroup;
  formElecDis: FormGroup;
  formPowerFeat: FormGroup;
  formWiring: FormGroup;
  formThermDiss: FormGroup;
  equipmentName: string;

  constructor(private route: ActivatedRoute, private _equipmentService: EquipmentsService, private _groupsService: GroupsService, private fb: FormBuilder) {
    this.formMotoEquip = fb.group({
      idtNumber: '',
      descEquip: '',
      revision: '',
      SuiviAsm: ''
    });

    this.formArea = fb.group({
      pidRef: '',
      numZone: '',
      file: '',
      zonePro: '',
      atelier: '',
      sousAtelier: '',
    });

    this.formOpeIn = fb.group({
      moteurImm: '',
      atex: '',
      package: '',
      backupGen: '',
      vfd: '',
      backupInverter: '',
      etat: '',
      packageTyp: ''
    });

    this.formElecDis = fb.group({
      transfo: '',
      tgbtLocation: '',
      mccLocation: '',
      departType: '',
      alimenElec: '',
      intensite: '',
      cosPhi: '',
      equipmentGroup: ''
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

  ngOnInit() {
    this.sub = this.route.params.subscribe(params => {
      this.idEquipmentSelect = +params['id'];
    });

    this.getEquipment(this.idEquipmentSelect);
    
  }

  ngOnDestroy(): void {
    this.sub.unsubscribe();
  }

  getEquipment(id: number) {
    this._equipmentService.getEquipment(id)
    .subscribe(
      (data) => this.equipmentData = data,
      (error) => console.log('error: '+error),
      ()=> {
        //Next Step
        this.getGroupInfo(this.equipmentData);
      }
    )
  }

  getGroupInfo(data: any) {
     this._groupsService.getGroup(this.equipmentData.GroupeId)
     .subscribe(
       (data) => {
         //Check if equipment had group
         if(data == undefined){
          this.equipGroupName = 'No Group'
         }else{
          this.equipGroupName = data.name
         }
       },
       (error) => console.log('error:' + error),
       ()=> {
         //Next Step
        this.updateFormsValue(data)
        console.log(data);
        this.equipmentName = data.IdtNumber;
        
       }
     )
  }

  updateFormsValue(data: any){
    
    this.formMotoEquip.patchValue({
      idtNumber: data.IdtNumber,
      descEquip: data.Description,
      revision: data.Revision,
      SuiviAsm: data.SuiviAsm,
    });

    this.formArea.patchValue({
      pidRef: data.Area.PIDReference,
      numZone: data.Area.NumeroZone,
      file: data.Area.File,
      zonePro: data.Area.ZoneProcess,
      atelier: data.Area.Atelier,
      sousAtelier: data.Area.SousAtelier,
    });

    this.formOpeIn.patchValue({
      moteurImm: data.OperatingInformations.MoteurImerge.toString(),
      atex: data.OperatingInformations.Atex,
      package: data.OperatingInformations.Package.toString(),
      backupGen: data.OperatingInformations.BackupGenset.toString(),
      vfd: data.OperatingInformations.Vfd.toString(),
      backupInverter: data.OperatingInformations.BackupInverter.toString(),
      etat: data.OperatingInformations.Etat.toString(),
      packageTyp: data.OperatingInformations.PackageTypique.toString()
    });

    this.formElecDis.patchValue({
      transfo: data.ElectricalDistributions.Transfo,
      tgbtLocation: data.ElectricalDistributions.TgbtLocation,
      mccLocation: data.ElectricalDistributions.MccLocation,
      departType: data.ElectricalDistributions.DepartType,
      alimenElec: data.ElectricalDistributions.AlimentationElectrique,
      intensite: data.ElectricalDistributions.Intensite,
      cosPhi: data.ElectricalDistributions.CosPhi,
      equipmentGroup: this.equipGroupName
    });

    this.formPowerFeat.patchValue({
      nominalInstPow: data.PowerFeatures.NominalInstalledPower,
      mechPowDemand: data.PowerFeatures.MechanicalPowerDemand,
      motorEfficiency: data.PowerFeatures.MotorEfficiency,
      motorEfficiencyCl: data.PowerFeatures.MotorEfficiencyClass,
      installAbsorPowDp: data.PowerFeatures.InstalledAbsorbedPowerDp,
      dutyAbsPow: data.PowerFeatures.DutyAbsorbedPower
    });

    this.formWiring.patchValue({
      typeCablePuissance: data.Cables.TypeCablePuissance,
      sectionCable: data.Cables.SectionCable,
      nbrCable: data.Cables.NombreCable,
      typeProtection: data.Cables.TypeCablePuissance,
      typeCableProtection: data.Cables.TypeProtection,
      typeCableCommande: data.Cables.TypeCableCommande,
      longueurCable: data.Cables.LongueurCable
    });

    this.formThermDiss.patchValue({
      hvac: data.ThermalDissipations.HVAC,
      heatDissipation: data.ThermalDissipations.HeatDissipation
    });
  }

}
