import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { MatchAdminCreateComponent } from './match-admin-create.component';

describe('MatchAdminCreateComponent', () => {
  let component: MatchAdminCreateComponent;
  let fixture: ComponentFixture<MatchAdminCreateComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ MatchAdminCreateComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(MatchAdminCreateComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
