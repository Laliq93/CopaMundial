import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { LogroEquipoComponent } from './logro-equipo.component';

describe('LogroEquipoComponent', () => {
  let component: LogroEquipoComponent;
  let fixture: ComponentFixture<LogroEquipoComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ LogroEquipoComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(LogroEquipoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
