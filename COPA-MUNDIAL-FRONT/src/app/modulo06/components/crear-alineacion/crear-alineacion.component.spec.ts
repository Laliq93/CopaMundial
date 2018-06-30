import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CrearAlineacionComponent } from './crear-alineacion.component';

describe('CrearAlineacionComponent', () => {
  let component: CrearAlineacionComponent;
  let fixture: ComponentFixture<CrearAlineacionComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CrearAlineacionComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CrearAlineacionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
