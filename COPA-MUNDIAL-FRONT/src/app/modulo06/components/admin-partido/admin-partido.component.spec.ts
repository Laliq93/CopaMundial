import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AdminPartidoComponent } from './admin-partido.component';

describe('AdminPartidoComponent', () => {
  let component: AdminPartidoComponent;
  let fixture: ComponentFixture<AdminPartidoComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AdminPartidoComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AdminPartidoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
