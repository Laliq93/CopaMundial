import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { RegistrarApuestaComponent } from './registrar-apuesta.component';

describe('RegistrarApuestaComponent', () => {
  let component: RegistrarApuestaComponent;
  let fixture: ComponentFixture<RegistrarApuestaComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ RegistrarApuestaComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(RegistrarApuestaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
