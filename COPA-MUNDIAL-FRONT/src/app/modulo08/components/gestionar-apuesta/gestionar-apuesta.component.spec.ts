import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { GestionarApuestaComponent } from './gestionar-apuesta.component';

describe('GestionarApuestaComponent', () => {
  let component: GestionarApuestaComponent;
  let fixture: ComponentFixture<GestionarApuestaComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ GestionarApuestaComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(GestionarApuestaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
