import { Injectable, isDevMode, OnInit } from '@angular/core';
import { Http } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import { Observer } from 'rxjs/Observer';
import { Subject } from 'rxjs/Subject';
import { SharedService } from '../../services/shared/shared.service';
import 'rxjs/Rx';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/do';  // debug
import 'rxjs/add/operator/catch';

@Injectable()
export class ProjectsService implements OnInit {
  ngOnInit(): void {
    
  }

  data: Observable<any>;
  urlData: any;
  dataObserver: Observer<any>; 
  serverPath: string;
  
  constructor(private _http: Http, private _sharedServide: SharedService) {
    this.data = new Observable((observer)=> this.dataObserver = observer);
    this.serverPath = SharedService.URLPATHSERVICE+'/Projects/';

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
