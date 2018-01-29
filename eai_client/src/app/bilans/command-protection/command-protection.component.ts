import { Component, OnInit } from '@angular/core';
import { EquipmentsService } from '../../services/equipments/equipments.service';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-command-protection',
  templateUrl: './command-protection.component.html',
  styleUrls: ['./command-protection.component.css'],
  providers: [EquipmentsService]
})
export class CommandProtectionComponent implements OnInit {

  dataCommandProtection: any;
  idProject: number;
  sub: any;
  formatData = [];
  cleanData = [];
  dataCompare = [];
  isPush: boolean = true;
  dataGroups: any;
  groupSelectId: number;

  constructor(private route: ActivatedRoute, private _equipmentService: EquipmentsService, private router: Router) {
    this.sub = this.route.params.subscribe(params => {
      this.idProject = params['idProject'];
   });
  }

  ngOnInit() {
    this.getThermalDissipation(this.idProject);
  }

  dataTransform(dataRaw: any){
    this.formatData = [];
    this.cleanData = [];

    // Order data table 
    dataRaw.forEach(element => {
      if(element.Groupe != null && element.ThermalDissipations != null){
        this.formatData.push({'SwitchBoard': element.Groupe.Name, 'Protection': element.Cables.TypeProtection, 'Number': 1});
      }
    });
    // this.formatData.push({'SwitchBoard': "SuperGroupeSuperGroupe", 'HeatDissipation': 1});
    // this.formatData.push({'SwitchBoard': "SuperGroupeSuperGroupe", 'HeatDissipation': 1});
    
    for (var i = 0; i < this.formatData.length; i++) {
      for (var y = 0; y < this.cleanData.length; y++) {
        if(this.formatData[i].SwitchBoard == this.cleanData[y].SwitchBoard && this.formatData[i].Protection == this.cleanData[y].Protection){
          this.isPush = false;
          this.cleanData[y].Number += this.formatData[i].Number;
        }
      }
      if(this.isPush == true){
        this.cleanData.push({'SwitchBoard': this.formatData[i].SwitchBoard, 'Protection': this.formatData[i].Protection, 'Number': this.formatData[i].Number});
      }
      this.isPush = true;
    }
  }


  getThermalDissipation(projectId: number):void{
    this._equipmentService.GetEquipmentsSpe(projectId)
    .subscribe(
      (data) => this.dataCommandProtection = data,
      (error) => console.log('thermal dissipation error'),
      () => {
        this.dataTransform(this.dataCommandProtection);
      }
    )
  }

  goToEquipList():void {
    this.router.navigateByUrl('/equipmentList/'+this.idProject);
  }

}
