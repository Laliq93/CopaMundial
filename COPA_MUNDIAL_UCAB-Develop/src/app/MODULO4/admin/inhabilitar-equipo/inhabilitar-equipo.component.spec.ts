import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { InhabilitarEquipoComponent } from './inhabilitar-equipo.component';

describe('InhabilitarEquipoComponent', () => {
  let component: InhabilitarEquipoComponent;
  let fixture: ComponentFixture<InhabilitarEquipoComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ InhabilitarEquipoComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(InhabilitarEquipoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
