import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { StadiumDetailAdminComponent } from './stadium-detail-admin.component';

describe('StadiumDetailAdminComponent', () => {
  let component: StadiumDetailAdminComponent;
  let fixture: ComponentFixture<StadiumDetailAdminComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ StadiumDetailAdminComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(StadiumDetailAdminComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
