import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AdminCalineacionComponent } from './admin-calineacion.component';

describe('AdminCalineacionComponent', () => {
  let component: AdminCalineacionComponent;
  let fixture: ComponentFixture<AdminCalineacionComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AdminCalineacionComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AdminCalineacionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
