import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CreateEquipStep1Component } from './create-equip-step1.component';

describe('CreateEquipStep1Component', () => {
  let component: CreateEquipStep1Component;
  let fixture: ComponentFixture<CreateEquipStep1Component>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CreateEquipStep1Component ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CreateEquipStep1Component);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
