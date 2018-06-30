import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { VerAlineacionComponent } from './ver-alineacion.component';

describe('VerAlineacionComponent', () => {
  let component: VerAlineacionComponent;
  let fixture: ComponentFixture<VerAlineacionComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ VerAlineacionComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(VerAlineacionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
