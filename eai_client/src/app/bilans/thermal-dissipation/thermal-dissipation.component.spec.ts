import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ThermalDissipationComponent } from './thermal-dissipation.component';

describe('ThermalDissipationComponent', () => {
  let component: ThermalDissipationComponent;
  let fixture: ComponentFixture<ThermalDissipationComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ThermalDissipationComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ThermalDissipationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
