import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { MatchAdminUpdateComponent } from './match-admin-update.component';

describe('MatchAdminUpdateComponent', () => {
  let component: MatchAdminUpdateComponent;
  let fixture: ComponentFixture<MatchAdminUpdateComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ MatchAdminUpdateComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(MatchAdminUpdateComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
