import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CommandProtectionComponent } from './command-protection.component';

describe('CommandProtectionComponent', () => {
  let component: CommandProtectionComponent;
  let fixture: ComponentFixture<CommandProtectionComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CommandProtectionComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CommandProtectionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
