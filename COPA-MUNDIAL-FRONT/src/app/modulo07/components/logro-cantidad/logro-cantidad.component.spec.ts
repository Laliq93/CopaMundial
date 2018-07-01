import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { LogroCantidadComponent } from './logro-cantidad.component';

describe('LogroCantidadComponent', () => {
  let component: LogroCantidadComponent;
  let fixture: ComponentFixture<LogroCantidadComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ LogroCantidadComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(LogroCantidadComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
