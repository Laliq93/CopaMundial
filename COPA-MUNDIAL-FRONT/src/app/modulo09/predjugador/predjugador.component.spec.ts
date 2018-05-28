import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PredjugadorComponent } from './predjugador.component';

describe('PredjugadorComponent', () => {
  let component: PredjugadorComponent;
  let fixture: ComponentFixture<PredjugadorComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PredjugadorComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PredjugadorComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
