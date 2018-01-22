import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { WiringPowerComponent } from './wiring-power.component';

describe('WiringPowerComponent', () => {
  let component: WiringPowerComponent;
  let fixture: ComponentFixture<WiringPowerComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ WiringPowerComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(WiringPowerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
