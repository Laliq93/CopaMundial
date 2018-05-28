import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { DatosTorneoComponent } from './datos-torneo.component';

describe('DatosTorneoComponent', () => {
  let component: DatosTorneoComponent;
  let fixture: ComponentFixture<DatosTorneoComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DatosTorneoComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DatosTorneoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
