import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AdminApuestaComponent } from './admin-apuesta.component';

describe('AdminApuestaComponent', () => {
  let component: AdminApuestaComponent;
  let fixture: ComponentFixture<AdminApuestaComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AdminApuestaComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AdminApuestaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
