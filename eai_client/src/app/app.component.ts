import { Component, OnDestroy } from '@angular/core';
import { SharedService } from './services/shared/shared.service';
import { Subscription } from 'rxjs/Subscription';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
  providers: [SharedService]
})
export class AppComponent implements OnDestroy {
  title = 'app';
  private _opened: boolean = false;
  message: any;
  subscription: Subscription;

  constructor(private messageService: SharedService) {
    // subscribe to home component messages
    // this.subscription = this.messageService.getMessage().subscribe(message => {
    //    console.log(message)
       
    // });
  }

  ngOnDestroy() {
    // unsubscribe to ensure no memory leaks
    this.subscription.unsubscribe();
  }

  private _toggleSidebar() {
    this._opened = !this._opened;
  }

}
