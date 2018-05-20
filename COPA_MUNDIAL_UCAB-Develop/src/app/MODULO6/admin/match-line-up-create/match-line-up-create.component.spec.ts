import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { MatchLineUpCreateComponent } from './match-line-up-create.component';

describe('MatchLineUpCreateComponent', () => {
  let component: MatchLineUpCreateComponent;
  let fixture: ComponentFixture<MatchLineUpCreateComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ MatchLineUpCreateComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(MatchLineUpCreateComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
