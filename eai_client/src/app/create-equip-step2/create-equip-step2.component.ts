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

    var equipIdtNumber = this.dataEquiment["MotorizedEquipment"].controls.idtNumber.value;
    var equipGroupId;;
    if(this.selectedGroup === undefined){
      equipGroupId = null;
    }else {
      equipGroupId = parseInt(this.selectedGroup.id);
    }
    
    var equipProjectId = this.projectId;
    console.log(equipGroupId);
    
 
    this._equipmentsService.insertEquipment(equipIdtNumber, equipGroupId, equipProjectId)
    .subscribe(
      (data) => this.dataEquipment = data,
      (error) => console.log(error),
      ()=>{
        this.router.navigate(['/equipmentList/'+this.projectId]);
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
