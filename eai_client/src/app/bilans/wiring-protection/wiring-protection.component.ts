import { Component, OnInit } from '@angular/core';
import { EquipmentsService } from '../../services/equipments/equipments.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-wiring-protection',
  templateUrl: './wiring-protection.component.html',
  styleUrls: ['./wiring-protection.component.css'],
  providers: [EquipmentsService]
})
export class WiringProtectionComponent implements OnInit {

  dataWiringPower: any;
  idProject: number;
  sub: any;
  formatData = [];
  cleanData = [];
  isPush: boolean = true;

  constructor(private route: ActivatedRoute, private _equipmentService: EquipmentsService) {
    this.sub = this.route.params.subscribe(params => {
      console.log(params['idProject']);
      this.idProject = params['idProject'];
   });
   }

  ngOnInit() {
    this.getWiringProtectionBilan(this.idProject);
  }

  dataTransform(dataRaw: any){
    this.formatData = [];
    this.cleanData = [];

    // Order data table 
    dataRaw.forEach(element => {
      this.formatData.push({'TypeCablePuissance': element.TypeCablePuissance, 'SectionCable': element.SectionCable,
      'Number': 0, 'quantity': element.LongueurCable, 'LongueurCable': element.LongueurCable})
    });

    // this.formatData.push({'TypeCablePuissance': 'format1', 'SectionCable': 2,
    // 'Number': 1, 'quantity': 2, 'LongueurCable': 5});

    // this.formatData.push({'TypeCablePuissance': 'format1', 'SectionCable': 3,
    // 'Number': 1, 'quantity': 2, 'LongueurCable': 5});

    for (var i = 0; i < this.formatData.length; i++) {
      for (var y = 0; y < this.cleanData.length; y++) {
        if(this.formatData[i].TypeCablePuissance == this.cleanData[y].TypeCablePuissance){
          this.isPush = false;
          this.cleanData[y].Number ++;
          this.cleanData[y].quantity += this.formatData[i].LongueurCable;
        }
      }
      if(this.isPush == true){
        this.cleanData.push({'TypeCablePuissance': this.formatData[i].TypeCablePuissance, 'SectionCable': this.formatData[i].SectionCable,'Number': 1, 'quantity': this.formatData[i].LongueurCable, LongueurCable: this.formatData[i].LongueurCable
        ,'Instrumentation': this.formatData[i].TypeCablePuissance});
      }
      this.isPush = true;
    }
    console.log(this.cleanData);
    
  }

  getWiringProtectionBilan(projectId: number) :void {
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
