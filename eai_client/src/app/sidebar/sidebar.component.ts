import { Component, OnInit, Output, Input, EventEmitter, AfterViewInit, OnDestroy } from '@angular/core';
import { SharedService } from '../services/shared/shared.service';
import { Subscription } from 'rxjs/Subscription';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-sidebar',
  templateUrl: './sidebar.component.html',
  styleUrls: ['./sidebar.component.css']
})
export class SidebarComponent implements OnInit, OnDestroy {

  private sub: any;
  private _opened: boolean = true;
  private _mode: string = 'push';
  subscription: Subscription;
  isDisplay: boolean = false;
  projectId: number;

  constructor(private messageService: SharedService, private route: ActivatedRoute){
    this.subscription = this.messageService.getMessage().subscribe(message =>{
      this.isDisplay = !this.isDisplay;
      this.projectId = message.text;
    });
  }

  ngOnInit(): void {
  }

  ngOnDestroy() {
    // unsubscribe to ensure no memory leaks
    this.subscription.unsubscribe();
  }

  private _toggleSidebar() {
    this._opened = !this._opened;
  }
}
