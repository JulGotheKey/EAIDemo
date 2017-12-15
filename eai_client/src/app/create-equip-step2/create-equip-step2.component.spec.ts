import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CreateEquipStep2Component } from './create-equip-step2.component';

describe('CreateEquipStep2Component', () => {
  let component: CreateEquipStep2Component;
  let fixture: ComponentFixture<CreateEquipStep2Component>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CreateEquipStep2Component ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CreateEquipStep2Component);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
