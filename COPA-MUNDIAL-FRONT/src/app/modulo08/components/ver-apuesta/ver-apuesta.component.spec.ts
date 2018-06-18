import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { VerApuestaComponent } from './ver-apuesta.component';

describe('VerApuestaComponent', () => {
  let component: VerApuestaComponent;
  let fixture: ComponentFixture<VerApuestaComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ VerApuestaComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(VerApuestaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
