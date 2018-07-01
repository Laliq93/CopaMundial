import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ModificarPartidoComponent } from './modificar-partido.component';

describe('ModificarPartidoComponent', () => {
  let component: ModificarPartidoComponent;
  let fixture: ComponentFixture<ModificarPartidoComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ModificarPartidoComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ModificarPartidoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
