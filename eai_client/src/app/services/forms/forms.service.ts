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
export class FormsService {

  data: Observable<any>;
  dataObserver: Observer<any>;
  serverpath: string;

  constructor(private _http: Http) {
    this.data = new Observable((observer) => this.dataObserver = observer);
    this.serverpath = SharedService.URLPATHSERVICE;
   }
  
  getAllProjects(): Observable<any> {
    return this._http.get(this.serverpath + 'GetAllProjects')
    .map(data => data.json());
  }

}
