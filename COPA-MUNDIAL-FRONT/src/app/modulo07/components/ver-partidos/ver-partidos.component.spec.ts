import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { VerPartidosComponent } from './ver-partidos.component';

describe('VerPartidosComponent', () => {
  let component: VerPartidosComponent;
  let fixture: ComponentFixture<VerPartidosComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ VerPartidosComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(VerPartidosComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
