import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import { Subject } from 'rxjs/Subject';
import { Http } from '@angular/http';
import { log } from 'util';

@Injectable()
export class SharedService {

  private result: any;
  constructor(private _http: Http) { }

  private subject = new Subject<any>();


  sendMessage(message: number) {
    this.subject.next({ text: message });
  }

  clearMessage() {
    this.subject.next();
  }

  getMessage(): Observable<any> {
    return this.subject.asObservable();
  }
}
