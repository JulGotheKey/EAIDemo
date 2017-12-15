import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, FormControl, Validators } from '@angular/forms';
import { ProjectsService } from '../services/projects/projects.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-create-project',
  templateUrl: './create-project.component.html',
  styleUrls: ['./create-project.component.css'],
  providers: [ProjectsService]
})
export class CreateProjectComponent implements OnInit {

  formCreateProject: FormGroup;
  rtrDataCreateProject: any;

  constructor(private fb: FormBuilder, private _projectService: ProjectsService, private router: Router) {
    this.formCreateProject = this.fb.group({
      projectName: '',
      projectDescription: ''
    });
   }

  ngOnInit() {
  }

  createProject(){
    console.log(this.formCreateProject.controls.projectName.value);
    this._projectService.createProject(this.formCreateProject.controls.projectName.value, this.formCreateProject.controls.projectDescription.value)
    .subscribe(
      (data) => this.rtrDataCreateProject = data,
      (error) => console.log('error: '+error),
      ()=> {
        this.router.navigate(['/project']);
      }
    );
  }
}
