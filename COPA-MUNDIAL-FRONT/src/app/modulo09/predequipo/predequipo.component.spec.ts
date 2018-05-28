import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PredequipoComponent } from './predequipo.component';

describe('PredequipoComponent', () => {
  let component: PredequipoComponent;
  let fixture: ComponentFixture<PredequipoComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PredequipoComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PredequipoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
