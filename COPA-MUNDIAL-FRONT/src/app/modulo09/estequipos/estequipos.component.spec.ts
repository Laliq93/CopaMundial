import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { EstequiposComponent } from './estequipos.component';

describe('EstequiposComponent', () => {
  let component: EstequiposComponent;
  let fixture: ComponentFixture<EstequiposComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ EstequiposComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(EstequiposComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
