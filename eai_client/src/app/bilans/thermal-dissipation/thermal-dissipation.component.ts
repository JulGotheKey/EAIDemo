import { Component, OnInit } from '@angular/core';
import { EquipmentsService } from '../../services/equipments/equipments.service';
import { ActivatedRoute } from '@angular/router';
import { GroupsService } from '../../services/groups/groups.service';
import { FormBuilder, FormGroup, FormControl, Validators } from '@angular/forms';

@Component({
  selector: 'app-thermal-dissipation',
  templateUrl: './thermal-dissipation.component.html',
  styleUrls: ['./thermal-dissipation.component.css'],
  providers: [GroupsService, EquipmentsService]
})
export class ThermalDissipationComponent implements OnInit {

  dataThermalDissipation: any;
  idProject: number;
  sub: any;
  formatData = [];
  cleanData = [];
  dataCompare = [];
  isPush: boolean = true;
  dataGroups: any;
  formUpdateGroupName: FormGroup;
  selectedGroup = {id: '', projectId: 0, name: '', groupSupId: 0};
  groupSelectId: number;

  constructor(private fb: FormBuilder, private route: ActivatedRoute, private _equipmentService: EquipmentsService, private _groupsService: GroupsService) {
    this.sub = this.route.params.subscribe(params => {
      console.log(params['idProject']);
      this.idProject = params['idProject'];
   });

   this.formUpdateGroupName = fb.group({
    selectGroup: this.selectedGroup
   });
   }

  ngOnInit() {
    this.getThermalDissipation(this.idProject);
  }

   dataTransform(dataRaw: any){
    this.formatData = [];
    this.cleanData = [];
    console.log(dataRaw);

    // Order data table 
    dataRaw.forEach(element => {
      if(element.Groupe != null && element.ThermalDissipations != null){
        this.formatData.push({'SwitchBoard': element.Groupe.Name, 'HeatDissipation': element.ThermalDissipations.HeatDissipation});
      }
    });
    // this.formatData.push({'SwitchBoard': "SuperGroupeSuperGroupe", 'HeatDissipation': 1});
    // this.formatData.push({'SwitchBoard': "SuperGroupeSuperGroupe", 'HeatDissipation': 1});
    
    for (var i = 0; i < this.formatData.length; i++) {
      for (var y = 0; y < this.cleanData.length; y++) {
        if(this.formatData[i].SwitchBoard == this.cleanData[y].SwitchBoard){
          this.isPush = false;
          this.cleanData[y].HeatDissipation += this.formatData[i].HeatDissipation;
        }
      }
      if(this.isPush == true){
        this.cleanData.push({'SwitchBoard': this.formatData[i].SwitchBoard, 'HeatDissipation': this.formatData[i].HeatDissipation});
      }
      this.isPush = true;
    }
    console.log(this.cleanData);
  }

   getThermalDissipation(projectId: number):void{
    this._equipmentService.GetEquipmentsSpe(projectId)
    .subscribe(
      (data) => this.dataThermalDissipation = data,
      (error) => console.log('thermal dissipation error'),
      () => {
        this.dataTransform(this.dataThermalDissipation);
      }
    )
  }
}
