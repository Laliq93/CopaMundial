import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { EstgeneralComponent } from './estgeneral.component';

describe('EstgeneralComponent', () => {
  let component: EstgeneralComponent;
  let fixture: ComponentFixture<EstgeneralComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ EstgeneralComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(EstgeneralComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
