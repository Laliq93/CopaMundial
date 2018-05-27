import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SeguridadUsuarioComponent } from './seguridad-usuario.component';

describe('SeguridadUsuarioComponent', () => {
  let component: SeguridadUsuarioComponent;
  let fixture: ComponentFixture<SeguridadUsuarioComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SeguridadUsuarioComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SeguridadUsuarioComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
