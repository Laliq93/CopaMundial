import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ConfiguracionUsuarioComponent } from './configuracion-usuario.component';

describe('ConfiguracionUsuarioComponent', () => {
  let component: ConfiguracionUsuarioComponent;
  let fixture: ComponentFixture<ConfiguracionUsuarioComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ConfiguracionUsuarioComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ConfiguracionUsuarioComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
