import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CrearPartidoComponent } from './crear-partido.component';

describe('CrearPartidoComponent', () => {
  let component: CrearPartidoComponent;
  let fixture: ComponentFixture<CrearPartidoComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CrearPartidoComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CrearPartidoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
