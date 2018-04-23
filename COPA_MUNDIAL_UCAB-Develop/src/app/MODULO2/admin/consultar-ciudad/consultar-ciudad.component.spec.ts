import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ConsultarCiudadComponent } from './consultar-ciudad.component';

describe('ConsultarCiudadComponent', () => {
  let component: ConsultarCiudadComponent;
  let fixture: ComponentFixture<ConsultarCiudadComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ConsultarCiudadComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ConsultarCiudadComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
