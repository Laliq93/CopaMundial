import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { LogroVFComponent } from './logro-vf.component';

describe('LogroVFComponent', () => {
  let component: LogroVFComponent;
  let fixture: ComponentFixture<LogroVFComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ LogroVFComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(LogroVFComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
