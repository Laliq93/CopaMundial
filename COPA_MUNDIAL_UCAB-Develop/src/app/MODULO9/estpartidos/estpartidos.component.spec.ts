import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { EstpartidosComponent } from './estpartidos.component';

describe('EstpartidosComponent', () => {
  let component: EstpartidosComponent;
  let fixture: ComponentFixture<EstpartidosComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ EstpartidosComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(EstpartidosComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
