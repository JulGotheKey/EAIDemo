import { Component, OnInit } from '@angular/core';
import { EquipmentsService } from '../../services/equipments/equipments.service';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-motor-starter',
  templateUrl: './motor-starter.component.html',
  styleUrls: ['./motor-starter.component.css'],
  providers: [EquipmentsService]
})
export class MotorStarterComponent implements OnInit {

  dataMotorStarter: any;
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
    this.getMotorStarter(this.idProject);
  }

  dataTransform(dataRaw: any){
    this.formatData = [];
    this.cleanData = [];

    // Order data table 
    dataRaw.forEach(element => {
      if(element.Groupe != null && element.ElectricalDistributions != null && element.PowerFeatures != null){
        this.formatData.push({'SwitchBoard': element.Groupe.Name, 'MotorStarterType': element.ElectricalDistributions.DepartType, 'Puissance': element.PowerFeatures.NominalInstalledPower, Number: 1});
      }
    });
    

    for (var i = 0; i < this.formatData.length; i++) {
      for (var y = 0; y < this.cleanData.length; y++) {
        if(this.formatData[i].SwitchBoard == this.cleanData[y].SwitchBoard && this.formatData[i].MotorStarterType == this.cleanData[y].MotorStarterType && this.formatData[i].Puissance == this.cleanData[y].Puissance){
          this.isPush = false;
          this.cleanData[y].Number += this.formatData[i].Number;
        }
      }
      if(this.isPush == true){
        this.cleanData.push({'SwitchBoard': this.formatData[i].SwitchBoard, 'MotorStarterType': this.formatData[i].MotorStarterType, 'Puissance': this.formatData[i].Puissance, 'Number':  this.formatData[i].Number});
      }
      this.isPush = true;
    }
  }

  getMotorStarter(projectId: number):void{
    this._equipmentService.GetEquipmentsSpe(projectId)
    .subscribe(
      (data) => this.dataMotorStarter = data,
      (error) => console.log('thermal dissipation error'),
      () => {
        this.dataTransform(this.dataMotorStarter);
      }
    )
  }

  goToEquipList(): void {
    this.router.navigateByUrl('/equipmentList/'+this.idProject);
  }

}
