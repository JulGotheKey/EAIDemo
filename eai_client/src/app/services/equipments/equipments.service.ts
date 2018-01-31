import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import { Observer } from 'rxjs/Observer';
import { Subject } from 'rxjs/Subject';
import { SharedService } from '../shared/shared.service';
import 'rxjs/Rx';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/do';  // debug
import 'rxjs/add/operator/catch';

@Injectable()
export class EquipmentsService {

  data: Observable<any>;
  dataObserver: Observer<any>;
  serverPath: string;

  constructor(private _http: Http) {
    this.data = new Observable((observer)=> this.dataObserver = observer);
    this.serverPath = SharedService.URLPATHSERVICE;
   }

   //TO POST Migration !!!
  //  public insertEquipment(equipmentIdtNumber: string, equipmentGroupId: number,  equipmentProjectId: number) :Observable<any> {
  //   return this._http.get(this.serverPath+'CreateSpecificEquipment/equipmentIdtNumber='+equipmentIdtNumber+'&groupeId='+equipmentGroupId+'&projectId='+equipmentProjectId);
  //  }

  public insertEquipment(equipment: any) :Observable<any> {
    console.log(equipment.ThermalDissipations);
    console.log(equipment.ThermalDissipations);
    console.log(equipment.ThermalDissipations);
    console.log(equipment.ThermalDissipations);
    
    return this._http.post(this.serverPath+'CreateSpecificEquipment', {
      OperatingInformations: {
      MoteurImerge: equipment.OperatingInformations.MoteurImerge, Atex : equipment.OperatingInformations.Atex,
      Package:  equipment.OperatingInformations.Package, BackupGenset : equipment.OperatingInformations.BackupGen, Vfd: equipment.OperatingInformations.Vfd,
      BackupInverter:  equipment.OperatingInformations.BackupInverter, Etat:  equipment.OperatingInformations.Etat, 
      PackageTypique :equipment.OperatingInformations.PackageTypique
      },
      ElectricalDistributions: {
        AlimentationElectrique: equipment.ElectricalDistributions.AlimentationElectrique ,cosPhi: equipment.ElectricalDistributions.CosPhi,
        departType: equipment.ElectricalDistributions.DepartType , intensite: equipment.ElectricalDistributions.Intensite
      },
      Areas: {
        Atelier: equipment.Areas.Atelier , File: equipment.Areas.File , NumeroZone: equipment.Areas.NumeroZone , 
        PIDReference: equipment.Areas.PIDReference , SousAtelier: equipment.Areas.SousAtelier ,
        ZoneProcess: equipment.Areas.ZoneProcess
      },
      PowerFeatures: {
        DutyAbsorbedPower: equipment.PowerFeatures.DutyAbsorbedPower , InstalledAbsorbedPowerDp: equipment.PowerFeatures.InstalledAbsorbedPowerDp , MechanicalPowerDemand: equipment.PowerFeatures.MechanicalPowerDemand , 
        MotorEfficiency: equipment.PowerFeatures.MotorEfficiency , MotorEfficiencyClass: equipment.PowerFeatures.MotorEfficiencyClass ,
        NominalInstalledPower: equipment.PowerFeatures.NominalInstalledPower
      },
      MotorizedEquipments: {
        SuiviAsm: equipment.MotorizedEquipments.SuiviAsm , Description: equipment.MotorizedEquipments.Description , 
        IdtNumber: equipment.MotorizedEquipments.IdtNumber , Revision: equipment.MotorizedEquipments.Revision
      },
      Cables: {
        LongueurCable: equipment.Cables.LongueurCable , SectionCable: equipment.Cables.SectionCable , TypeCableCommande: equipment.Cables.TypeCableCommande , 
        TypeCableProtection: equipment.Cables.TypeCableProtection , TypeCablePuissance: equipment.Cables.TypeCablePuissance,
        TypeProtection: equipment.Cables.TypeProtection, NombreCable: equipment.Cables.NombreCable
      },
      ThermalDissipations: {
        HeatDissipation: equipment.ThermalDissipations.HeatDissipation, HVAC: equipment.ThermalDissipations.HVAC
      },
      Infos: {
        ProjectId: equipment.Infos.ProjectId, GroupeId: equipment.Infos.GroupeId, IdtNumber: equipment.Infos.IdtNumber
      }
    });
   }



   public getEquipments(equipmentId: number) :Observable<any> {
    return this._http.get(this.serverPath + 'GetEquipments/projectId=' + equipmentId).map((data) => data.json());
   }

   public getEquipment(equipmentId: number) :Observable<any> {
    return this._http.get(this.serverPath + 'GetEquipmentSpe/equipmentId=' + equipmentId).map((data) => data.json()[0]);
   }

   public getEquipmentsByGroup(projectId: number) :Observable<any> {
    return this._http.get(this.serverPath + 'GetEquipmentsByGroup/projectId=' + projectId).map((data) => data.json());
  }

   //Equipment specification

   public GetEquipmentsSpe(projectId: number) :Observable<any> {
     return this._http.get(this.serverPath + 'GetEquipmentsSpe/projectId=' + projectId).map((data) => data.json());
   }   

   public getWiringPower(projectId: number) :Observable<any> {
     return this._http.get(this.serverPath + 'getWiringPower/projectId=' + projectId).map((data) => data.json());
   }

   public getThermalDissipation(projectId: number) :Observable<any> {
    return this._http.get(this.serverPath + 'GetEquipmentsSpe/projectId=' + projectId).map((data) => data.json());
   }
}
