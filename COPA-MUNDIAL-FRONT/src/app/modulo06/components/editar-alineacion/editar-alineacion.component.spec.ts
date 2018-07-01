import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { EditarAlineacionComponent } from './editar-alineacion.component';

describe('EditarAlineacionComponent', () => {
  let component: EditarAlineacionComponent;
  let fixture: ComponentFixture<EditarAlineacionComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ EditarAlineacionComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(EditarAlineacionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
