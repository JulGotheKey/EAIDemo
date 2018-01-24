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
export class ProjectsService {

  data: Observable<any>;
  dataObserver: Observer<any>;
  serverPath: string;

  constructor(private _http: Http) {
    this.data = new Observable((observer)=> this.dataObserver = observer);
    // this.serverPath = 'http://localhost:54497/api/Projects/';
    this.serverPath = 'http://frstm01aplu1:8086/api/Projects/';

   }

   public createProject(projectName: string, projectDescription: string) :Observable<any> {
     return this._http.post(this.serverPath + 'CreateProjectPost', { projectName : projectName, projectDescription: projectDescription });
   }

   public getProjects() :Observable<any> {
     return this._http.get(this.serverPath + 'GetAllProjects').map((data) => data.json());
   }

   public getProject(projectId: number) :Observable<any> {
     return this._http.get(this.serverPath + 'GetProject/projectId=' + projectId).map((data) => data.json());
   }

}
