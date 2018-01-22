import { Component, OnInit } from '@angular/core';
import { EquipmentsService } from '../../services/equipments/equipments.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-wiring-power',
  templateUrl: './wiring-power.component.html',
  styleUrls: ['./wiring-power.component.css'],
  providers: [EquipmentsService]
})
export class WiringPowerComponent implements OnInit {

  dataWiringPower: any;
  idProject: number;
  sub: any;
  formatData = [];
  cleanData = [];
  dataCompare = [];
  isPush: boolean = true;

  constructor(private route: ActivatedRoute, private _equipmentService: EquipmentsService) {
    this.sub = this.route.params.subscribe(params => {
      console.log(params['idProject']);
      this.idProject = params['idProject'];
   });
   }

  ngOnInit() {
    this.getWiringPowerBilan(this.idProject);
  }

  dataTransform(dataRaw: any){
    this.formatData = [];
    this.cleanData = [];

    // Order data table 
    dataRaw.forEach(element => {
      this.formatData.push({'TypeCablePuissance': element.TypeCablePuissance, 'SectionCable': element.SectionCable,
      'Number': 0, 'quantity': element.LongueurCable, 'LongueurCable': element.LongueurCable})
    });
    
    for (var i = 0; i < this.formatData.length; i++) {
      for (var y = 0; y < this.cleanData.length; y++) {
        if(this.formatData[i].TypeCablePuissance == this.cleanData[y].TypeCablePuissance && this.formatData[i].SectionCable == this.cleanData[y].SectionCable){
          this.isPush = false;
          this.cleanData[y].Number ++;
          this.cleanData[y].quantity += this.formatData[i].LongueurCable;
        }
      }
      if(this.isPush == true){
        this.cleanData.push({'TypeCablePuissance': this.formatData[i].TypeCablePuissance, 'SectionCable': this.formatData[i].SectionCable,'Number': 1, 'quantity': this.formatData[i].LongueurCable, LongueurCable: this.formatData[i].LongueurCable
        ,'PowerCable': this.formatData[i].TypeCablePuissance + ' ' + this.formatData[i].SectionCable});
      }
      this.isPush = true;
    }
    console.log(this.cleanData);
  }

  getWiringPowerBilan(projectId: number):void{
    this._equipmentService.getWiringPower(projectId)
    .subscribe(
      (data) => this.dataWiringPower = data,
      (error) => console.log('wiring power error'),
      () => {
        this.dataTransform(this.dataWiringPower)
      }
    )
  }
}
