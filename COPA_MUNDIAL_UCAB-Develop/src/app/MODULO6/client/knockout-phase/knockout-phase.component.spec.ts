import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { KnockoutPhaseComponent } from './knockout-phase.component';

describe('KnockoutPhaseComponent', () => {
  let component: KnockoutPhaseComponent;
  let fixture: ComponentFixture<KnockoutPhaseComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ KnockoutPhaseComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(KnockoutPhaseComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
