import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, FormControl, Validators } from '@angular/forms';
import { ProjectsService } from '../services/projects/projects.service';
import { EquipmentsService } from '../services/equipments/equipments.service';

import { TemplateRef } from '@angular/core';
import { BsModalService } from 'ngx-bootstrap/modal';
import { BsModalRef } from 'ngx-bootstrap/modal/modal-options.class';

import { Project } from '../models/project';

@Component({
  selector: 'app-project',
  templateUrl: './project.component.html',
  styleUrls: ['./project.component.css'],
  providers: [ProjectsService, EquipmentsService]
})
export class ProjectComponent implements OnInit {

  //Dates are generated on the server side
  form: FormGroup;
  projectName: string;
  projectDescription: string;
  dataProject: any;

  dataProjects = [];
  dataProjectSelect = [];
  dataEquipments = [];

  constructor(private fb: FormBuilder, private _projectService: ProjectsService, private _equipmentService: EquipmentsService){
    this.form = fb.group({
      projectName: '',
      projectDescription: ''
    })
  }

  toggleCreate: boolean = false;
  toggleProjList: boolean = true;
  toggleEquipList: boolean = false;

  ngOnInit() {
  }

  createProject(): void {
    this.projectName = this.form.controls.projectName.value;
    this.projectDescription = this.form.controls.projectDescription.value;

    this._projectService.createProject(this.projectName, this.projectDescription)
    .subscribe(
      (data) => this.dataProject = data,
      (error) => console.log('error: '+error),
      ()=>{
        this.form.reset();
      }
    );
  }

  // public toggleCreateF() :void {
  //   this.toggleCreate = !this.toggleCreate;
  //   this.toggleProjList = !this.toggleProjList;
  //   this.toggleEquipList = false;
  //  }

  //  public toggleSelectF() :void {
  //   this.toggleEquipList = !this.toggleEquipList;
  //   this.toggleProjList = !this.toggleProjList;
  //  }
   
  //  public backToPjList() :void {
  //    this.toggleEquipList = false;
  //    this.toggleProjList = true;
  //  }

}
