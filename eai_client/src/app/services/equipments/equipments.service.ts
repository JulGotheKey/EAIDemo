import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import { Observer } from 'rxjs/Observer';
import { Subject } from 'rxjs/Subject';
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
    this.serverPath = 'http://localhost:54497/api/Equipments/';
   }

   //TO POST Migration !!!
   public insertEquipment(equipmentIdtNumber: string, equipmentGroupId: number,  equipmentProjectId: number) :Observable<any> {
    return this._http.get(this.serverPath+'CreateSpecificEquipment/equipmentIdtNumber='+equipmentIdtNumber+'&groupeId='+equipmentGroupId+'&projectId='+equipmentProjectId);
   }

   public getEquipments(equipmentId: number) :Observable<any> {
    return this._http.get(this.serverPath + 'GetEquipments/projectId=' + equipmentId).map((data) => data.json());
   }

   public getEquipment(equipmentId: number) :Observable<any> {
    return this._http.get(this.serverPath + 'GetEquipmentSpe/equipmentId=' + equipmentId).map((data) => data.json()[0]);
   }

}
