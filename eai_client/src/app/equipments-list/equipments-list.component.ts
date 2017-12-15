import { Component, OnInit, Input, Output, EventEmitter, OnDestroy } from '@angular/core';
import { EquipmentsService } from '../services/equipments/equipments.service';
import { ProjectsService } from '../services/projects/projects.service';
import { ActivatedRoute, Router } from '@angular/router';
import { SharedService } from '../services/shared/shared.service';


@Component({
  selector: 'app-equipments-list',
  templateUrl: './equipments-list.component.html',
  styleUrls: ['./equipments-list.component.css'],
  providers: [EquipmentsService, ProjectsService]
})
export class EquipmentsListComponent implements OnInit, OnDestroy {

  private sub: any;
  projectId: number;
  dataEquipments = [];
  dataProject: any;
  projectName: string;
  @Output() backToProjects = new EventEmitter();
  @Input() equipments;
  constructor(private _equipmentService: EquipmentsService, private route: ActivatedRoute, private router: Router, private _projectService: ProjectsService, private sharedService: SharedService) { 
    
  }

  ngOnInit() {
    this.sub = this.route.params.subscribe(params => {
      this.projectId = +params['id']; // (+) converts string 'id' to a number
      // In a real app: dispatch action to load the details here.
   });
   this.getEquipments();
   this.getProject(this.projectId);
   this.sharedService.sendMessage('letDisplay');
   
  }

  ngOnDestroy(): void {
    this.sharedService.sendMessage('letHide');
    
  }


  getEquipments():void {
    this._equipmentService.getEquipments(this.projectId)
    .subscribe(
      (data) => this.dataEquipments = data,
      (error) => console.log('error: ' + error),
      () => {
        this.getFirstChar(this.dataEquipments);
      }
    );
  }

  getFirstChar(equipments: any): void {
    equipments.forEach(element => {
      element.firstChar = element.idtNumber.charAt(0);
    });
    this.dataEquipments = equipments;
    
  }

  getProject(projectId :any):void {
    this._projectService.getProject(projectId).
      subscribe(
        (data) => this.dataProject = data,
        (error) => console.log(error),
        ()=>{
          this.projectName = this.dataProject.name;
        }
      )
  }

  goToPjList():void {
    this.router.navigateByUrl('/project');
  }

  goToCreateEquip(): void {
    this.router.navigateByUrl('/createEquipment/' + this.projectId);
  }

  goToManageGroups(): void {
    this.router.navigateByUrl('/manageGroups/' + this.projectId);
  }
}
