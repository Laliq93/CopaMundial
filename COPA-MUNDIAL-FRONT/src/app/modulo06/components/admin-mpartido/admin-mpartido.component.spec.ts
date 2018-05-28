import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AdminMpartidoComponent } from './admin-mpartido.component';

describe('AdminMpartidoComponent', () => {
  let component: AdminMpartidoComponent;
  let fixture: ComponentFixture<AdminMpartidoComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AdminMpartidoComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AdminMpartidoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
