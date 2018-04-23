import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { EliminarCiudadComponent } from './eliminar-ciudad.component';

describe('EliminarCiudadComponent', () => {
  let component: EliminarCiudadComponent;
  let fixture: ComponentFixture<EliminarCiudadComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ EliminarCiudadComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(EliminarCiudadComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
