import { Component, OnInit } from '@angular/core';
import { SharedService } from '../services/shared/shared.service';

@Component({
  selector: 'app-main',
  templateUrl: './main.component.html',
  styleUrls: ['./main.component.css'],
  providers: [SharedService]
})
export class MainComponent implements OnInit {
  urlData: string;
  constructor(private _sharedServide: SharedService) { }

  ngOnInit() {
  }

}
