import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, FormControl, Validators } from '@angular/forms';

@Component({
  selector: 'app-create-equipment',
  templateUrl: './create-equipment.component.html',
  styleUrls: ['./create-equipment.component.css']
})
export class CreateEquipmentComponent implements OnInit {

  StepConftoggle: boolean = true;
  outputDataEquip: any = [];
  formMotoEquip: FormGroup;
  
  constructor() {
   }

  ngOnInit() {
  }

  toggleStepConf(outputData: any): void {
    this.outputDataEquip = outputData;
    this.StepConftoggle = !this.StepConftoggle;
  }

}
