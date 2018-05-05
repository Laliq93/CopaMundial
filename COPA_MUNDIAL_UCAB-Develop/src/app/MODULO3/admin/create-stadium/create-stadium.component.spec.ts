import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CreateStadiumComponent } from './create-stadium.component';

describe('CreateStadiumComponent', () => {
  let component: CreateStadiumComponent;
  let fixture: ComponentFixture<CreateStadiumComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CreateStadiumComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CreateStadiumComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
