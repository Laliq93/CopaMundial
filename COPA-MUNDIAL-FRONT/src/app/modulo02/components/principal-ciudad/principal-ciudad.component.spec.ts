import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PrincipalCiudadComponent } from './principal-ciudad.component';

describe('PrincipalCiudadComponent', () => {
  let component: PrincipalCiudadComponent;
  let fixture: ComponentFixture<PrincipalCiudadComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PrincipalCiudadComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PrincipalCiudadComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
