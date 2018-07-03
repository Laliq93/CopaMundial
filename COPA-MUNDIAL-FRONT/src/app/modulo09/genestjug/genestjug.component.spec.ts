import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { GenestjugComponent } from './genestjug.component';

describe('GenestjugComponent', () => {
  let component: GenestjugComponent;
  let fixture: ComponentFixture<GenestjugComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ GenestjugComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(GenestjugComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
