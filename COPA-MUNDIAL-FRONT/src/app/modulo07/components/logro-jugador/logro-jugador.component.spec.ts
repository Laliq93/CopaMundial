import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { LogroJugadorComponent } from './logro-jugador.component';

describe('LogroJugadorComponent', () => {
  let component: LogroJugadorComponent;
  let fixture: ComponentFixture<LogroJugadorComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ LogroJugadorComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(LogroJugadorComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
