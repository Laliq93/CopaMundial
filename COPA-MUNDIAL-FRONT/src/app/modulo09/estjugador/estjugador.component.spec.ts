import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { EstjugadorComponent } from './estjugador.component';

describe('EstjugadorComponent', () => {
  let component: EstjugadorComponent;
  let fixture: ComponentFixture<EstjugadorComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ EstjugadorComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(EstjugadorComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
