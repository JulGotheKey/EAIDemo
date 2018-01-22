import { Component, OnInit, Input } from '@angular/core';
import { FormBuilder, FormGroup, FormControl, Validators } from '@angular/forms';
import { GroupsService } from '../services/groups/groups.service';
import { EquipmentsService } from '../services/equipments/equipments.service';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-create-equip-step2',
  templateUrl: './create-equip-step2.component.html',
  styleUrls: ['./create-equip-step2.component.css'],
  providers: [GroupsService, EquipmentsService]
})
export class CreateEquipStep2Component implements OnInit {

  @Input() dataEquiment;
  formConfigGroup: FormGroup;
  dataGroups: any;
  dataEquipment: any;
  private sub: any;
  projectId: number;
  selectedGroup = {id: '', projectId: ''};
  dataFluidSchema: any;
  cleanData = [];
  
  constructor(private fb: FormBuilder, private _groupsService: GroupsService, private _equipmentsService: EquipmentsService, private route: ActivatedRoute, private router: Router) {
    this.formConfigGroup = fb.group({
      idtNumber: ""
    }) 
   }

  ngOnInit() {
    this.sub = this.route.params.subscribe(params => {
      this.projectId = +params['idProject']; // (+) converts string 'id' to a number
   });

    this._groupsService.getGroups(this.projectId)
    .subscribe(
      (data) => this.dataGroups = data,
      (error) => console.log('error: '+ error),
      ()=>console.log(this.dataGroups)
    );
    this.letSchemGroup();
  }

  createEquipment() {

    var areaForm = this.dataEquiment["Area"].controls;
    var operatingForm = this.dataEquiment["OperatingInformation"].controls;
    var electricalDisForm = this.dataEquiment["ElectricalDistribution"].controls;
    var powerFeatForm = this.dataEquiment["PowerFeature"].controls;
    var cableForm = this.dataEquiment["Cable"].controls;
    var thermalDissForm = this.dataEquiment["ThermalDissipation"].controls;
    var motorizedEquip = this.dataEquiment["MotorizedEquipment"].controls;

    var equipIdtNumber = this.dataEquiment["MotorizedEquipment"].controls.idtNumber.value;

    var equipGroupId;;
    if(this.selectedGroup === undefined){
      equipGroupId = null;
    }else {
      equipGroupId = parseInt(this.selectedGroup.id);
    }

    this.cleanData["MotorizedEquipments"] = {IdtNumber: motorizedEquip.idtNumber.value, Description: motorizedEquip.descEquip.value,
      SuiviAsm: motorizedEquip.SuiviAsm.value, Revision: motorizedEquip.revision.value}

    this.cleanData["Areas"] = {PIDReference: areaForm.pidRef.value, NumeroZone: areaForm.numZone.value, 
      File: areaForm.file.value, ZoneProcess: areaForm.zonePro.value, Atelier: areaForm.atelier.value, SousAtelier: areaForm.sousAtelier.value};

    this.cleanData["OperatingInformations"] = {MoteurImerge: operatingForm.moteurImm.value , Atex : operatingForm.atex.value,
      Package: operatingForm.package.value , BackupGenset : operatingForm.backupGen.value, Vfd: operatingForm.vfd.value,
      BackupInverter: operatingForm.backupInverter.value , Etat: operatingForm.etat.value , 
      PackageTypique :operatingForm.packageTyp.value};

    this.cleanData["ElectricalDistributions"] = {Transfo: 1, TgbtLocation: 1, MccLocation: 1, 
      DepartType: electricalDisForm.departType.value, AlimentationElectrique: electricalDisForm.alimenElec.value,
      Intensite: electricalDisForm.intensite.value, CosPhi: electricalDisForm.cosPhi.value};

    this.cleanData["PowerFeatures"] = {NominalInstalledPower: powerFeatForm.nominalInstPow.value, MechanicalPowerDemand: powerFeatForm.mechPowDemand.value,
       MotorEfficiency: powerFeatForm.nominalInstPow.value, MotorEfficiencyClass: powerFeatForm.motorEfficiencyCl.value, 
       InstalledAbsorbedPowerDp: powerFeatForm.installAbsorPowDp.value, DutyAbsorbedPower: powerFeatForm.dutyAbsPow.value};
    
    this.cleanData["Cables"] = {TypeCablePuissance: cableForm.typeCablePuissance.value, SectionCable: cableForm.sectionCable.value, 
      NombreCable: cableForm.nbrCable.value, TypeProtection: cableForm.typeProtection.value, TypeCableProtection: cableForm.typeCableProtection.value, 
      TypeCableCommande: cableForm.typeCableCommande.value, LongueurCable: cableForm.longueurCable.value};

      this.cleanData["ThermalDissipations"] = {HeatDissipation: thermalDissForm.heatDissipation.value, HVAC: thermalDissForm.hvac.value}

    var equipProjectId = this.projectId;
    
 
    this._equipmentsService.insertEquipment(equipIdtNumber, equipGroupId, equipProjectId, this.cleanData)
    .subscribe(
      (data) => this.dataEquipment = data,
      (error) => console.log(error),
      ()=>{
        this.router.navigate(['/equipmentList/'+this.projectId]);
        console.log(this.dataEquiment);
        
      }
    );
  }
  
  letSchemGroup(): void{
    this._groupsService.getSchemaGroup(this.projectId).then(
     res => {
       console.log("API Success!");
       console.log(res);
       this.dataFluidSchema = res;
     },
     msg =>{
       console.log("API Down :(");
     }
   );
  }


}
