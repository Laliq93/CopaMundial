import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AdminCpartidoComponent } from './admin-cpartido.component';

describe('AdminCpartidoComponent', () => {
  let component: AdminCpartidoComponent;
  let fixture: ComponentFixture<AdminCpartidoComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AdminCpartidoComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AdminCpartidoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
