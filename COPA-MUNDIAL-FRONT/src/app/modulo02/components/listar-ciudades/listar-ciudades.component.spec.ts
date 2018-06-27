import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ListarCiudadesComponent } from './listar-ciudades.component';

describe('ListarCiudadesComponent', () => {
  let component: ListarCiudadesComponent;
  let fixture: ComponentFixture<ListarCiudadesComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ListarCiudadesComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ListarCiudadesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
