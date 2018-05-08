import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { DetalleCiudadComponent } from './detalle-ciudad.component';

describe('DetalleCiudadComponent', () => {
  let component: DetalleCiudadComponent;
  let fixture: ComponentFixture<DetalleCiudadComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DetalleCiudadComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DetalleCiudadComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
