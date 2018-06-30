import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { HistorialApuestaComponent } from './historial-apuesta.component';

describe('HistorialApuestaComponent', () => {
  let component: HistorialApuestaComponent;
  let fixture: ComponentFixture<HistorialApuestaComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ HistorialApuestaComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(HistorialApuestaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
