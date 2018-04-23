import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { StadiumDetailComponent } from './stadium-detail.component';

describe('StadiumDetailComponent', () => {
  let component: StadiumDetailComponent;
  let fixture: ComponentFixture<StadiumDetailComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ StadiumDetailComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(StadiumDetailComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
