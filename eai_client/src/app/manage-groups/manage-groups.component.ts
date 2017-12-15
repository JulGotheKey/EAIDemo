import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, FormControl, Validators } from '@angular/forms';
import { GroupsService } from '../services/groups/groups.service';
import { ActivatedRoute, Router } from '@angular/router';


@Component({
  selector: 'app-manage-groups',
  templateUrl: './manage-groups.component.html',
  styleUrls: ['./manage-groups.component.css'],
  providers: [GroupsService]
})
export class ManageGroupsComponent implements OnInit {

  formAddGroup: FormGroup;
  formUpdateGroupName: FormGroup;
  formRemoveGroup: FormGroup;

  dataGroups: any;
  dataGroupRtr: any;
  private sub: any;
  projectId: number;
  groupModel: any;
  selectedGroup = {id: '', projectId: 0, name: '', groupSupId: 0};

  dataSchema: any;
  dataFluidSchema: any;


  ngOnInit(): void {
    this.fetchGroups();
    this.letSchemGroup();
  }

  constructor(private fb: FormBuilder, private _groupsService: GroupsService, private route: ActivatedRoute) {
    this.sub = this.route.params.subscribe(params => {
      this.projectId = +params['idProject']; // (+) converts string 'id' to a number
   });

   this.formAddGroup = fb.group({
    groupName: '',
    selectGroup: this.selectedGroup
   });

   this.formUpdateGroupName = fb.group({
    newName: '',
    selectGroup: this.selectedGroup
   });

   this.formRemoveGroup = fb.group({
     selectGroup: this.selectedGroup
   })

   }

   AddGroup(){
     this._groupsService.insertGroup(this.formAddGroup.value.groupName, this.formAddGroup.value.selectGroup.id, this.projectId)
     .subscribe(
      (data) => this.dataGroupRtr = data,
      (error) => console.log(error),
      ()=>{
        this.fetchGroups();
        this.letSchemGroup();
      }
     );
   }

   UpdateGroup(){
     
    console.log(this.formUpdateGroupName.value.selectGroup.id);
    console.log(this.formUpdateGroupName.value.newName);
    this._groupsService.updateGroupName(this.formUpdateGroupName.value.selectGroup.id, this.formUpdateGroupName.value.newName)
    .subscribe(
      (data) => this.dataGroupRtr = data,
      (error) => console.log(error),
      ()=>{
        this.fetchGroups();
        this.letSchemGroup();
      }
    )
     
   }

   RemoveGroup(){
     this._groupsService.removeGroup(this.formRemoveGroup.value.selectGroup.id)
     .subscribe(
      (data) => this.dataGroupRtr = data,
      (error) => console.log(error),
      ()=>{
        console.log(this.dataGroupRtr);
        this.fetchGroups();
        this.letSchemGroup();
      }
     )
   }

   fetchGroups(): void {
    this._groupsService.getGroups(this.projectId)
      .subscribe(
        (data) => this.dataGroups = data,
        (error) => console.log('error: '+ error),
        ()=>console.log(this.dataGroups)
      );
   }

   convertFluidSchem(rawShem: any): void{
    this.dataFluidSchema = rawShem.replace(/SousGroupes/g , "children");
    this.dataFluidSchema = this.dataFluidSchema.replace(/Name/g , "name");
    this.dataFluidSchema = this.dataFluidSchema.replace(/Id/g , "id");
    this.dataFluidSchema = JSON.parse(this.dataFluidSchema);
    console.log(this.dataFluidSchema);
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
