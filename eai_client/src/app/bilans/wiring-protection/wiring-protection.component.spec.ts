import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { WiringProtectionComponent } from './wiring-protection.component';

describe('WiringProtectionComponent', () => {
  let component: WiringProtectionComponent;
  let fixture: ComponentFixture<WiringProtectionComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ WiringProtectionComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(WiringProtectionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
