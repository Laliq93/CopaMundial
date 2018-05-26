import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { EstpartidoComponent } from './estpartido.component';

describe('EstpartidoComponent', () => {
  let component: EstpartidoComponent;
  let fixture: ComponentFixture<EstpartidoComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ EstpartidoComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(EstpartidoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
