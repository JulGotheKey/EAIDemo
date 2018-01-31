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

export class GroupsService {

  data: Observable<any>;
  dataObserver: Observer<any>;
  serverPath: string;
  nodeResults: any;

  constructor(private _http: Http) {
    this.data = new Observable((observer)=> this.dataObserver = observer);
    this.serverPath = SharedService.URLPATHSERVICE;
   }

  public getGroups(projectId: number) :Observable<any> {
    return this._http.get(this.serverPath + 'GetGroups/projectId=' + projectId).map((data) => data.json());
  }

  public getGroup(groupId: number): Observable<any> {
    return this._http.get(this.serverPath + 'GetGroup/groupId=' + groupId).map((data) => data.json());
  }

  //TO POST !!!!!
  public insertGroup(groupName: string, groupSup: number, groupProjectId: number) :Observable<any> {
    return this._http.get(this.serverPath + 'InsertGroup/groupName=' + groupName +'&groupSupId=' + groupSup + '&groupProjectId='+groupProjectId);
  }

  public updateGroupName(groupId: number, groupNewName: string): Observable<any> {
    return this._http.get(this.serverPath + 'UpdateGroupName/groupId=' + groupId + '&groupNewName='+ groupNewName);
  }

  public removeGroup(groupId: number): Observable<any>{
    return this._http.get(this.serverPath + 'RemoveGroup/groupId=' + groupId);
  }

  public getSchemaGroup(projectId: number): Promise<any>{

    let promise = new Promise((resolve, reject)=>{
      let apiURL = this.serverPath + 'SortSchemGroup/projectId=' + projectId;
      this._http.get(apiURL)
      .toPromise()
      .then(
        res => {
          this.nodeResults = res.json();
          this.nodeResults = this.nodeResults.replace(/SousGroupes/g , "children");
          this.nodeResults = this.nodeResults.replace(/Name/g , "name");
          this.nodeResults = this.nodeResults.replace(/Id/g , "id");
          this.nodeResults = JSON.parse(this.nodeResults);
          let arrayNode = [];
          arrayNode.push(this.nodeResults);
          //console.log(arrayNode);
          resolve(arrayNode);
        },
        msg =>{
          reject(msg);
        }
      );
    });
    return promise;
  }
  
}
