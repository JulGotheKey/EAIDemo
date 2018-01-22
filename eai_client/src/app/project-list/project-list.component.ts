import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ProjectsService } from '../services/projects/projects.service';
import { EquipmentsService } from '../services/equipments/equipments.service';
import { SharedService } from '../services/shared/shared.service';

@Component({
  selector: 'app-project-list',
  templateUrl: './project-list.component.html',
  styleUrls: ['./project-list.component.css'],
  providers: [ProjectsService]
})
export class ProjectListComponent implements OnInit {


  //Dates are generated on the server side

  projectName: string;
  projectDescription: string;
  dataProject: any;

  dataProjects = [];
  dataProjectSelect = [];


  toggleEquipList: boolean;

  constructor(private _projectService: ProjectsService, private router: Router, private messageService: SharedService) {

   }

  ngOnInit() {
    this.toggleEquipList = false;
    this.getProjects();
  }

  goFun(){
    //To update
    this.messageService.sendMessage(1);
  }

  getProjects (): void {
    this._projectService.getProjects().subscribe(
      (data) => this.dataProjects = data,
      (error) => console.log('error: ' + error),
      () => {
        this.getFirstChar(this.dataProjects)
      }
    );
  }


  getFirstChar(projects: any): void {
    projects.forEach(element => {
      element.firstChar = element.name.charAt(0);
    });
    this.dataProject = projects;
    
  }

  public projectSelect(projectSelect: any) :void {
    console.log(projectSelect);
    this.router.navigateByUrl('/equipmentList/'+ projectSelect.id );
   }

}
