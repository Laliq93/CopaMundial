import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { EditarEquipoComponent } from './editar-equipo.component';

describe('EditarEquipoComponent', () => {
  let component: EditarEquipoComponent;
  let fixture: ComponentFixture<EditarEquipoComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ EditarEquipoComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(EditarEquipoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
