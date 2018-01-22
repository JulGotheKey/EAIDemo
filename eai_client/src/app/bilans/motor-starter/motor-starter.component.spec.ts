import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { MotorStarterComponent } from './motor-starter.component';

describe('MotorStarterComponent', () => {
  let component: MotorStarterComponent;
  let fixture: ComponentFixture<MotorStarterComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ MotorStarterComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(MotorStarterComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
