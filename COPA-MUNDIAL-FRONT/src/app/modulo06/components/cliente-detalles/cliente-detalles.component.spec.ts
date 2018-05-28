import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ClienteDetallesComponent } from './cliente-detalles.component';

describe('ClienteDetallesComponent', () => {
  let component: ClienteDetallesComponent;
  let fixture: ComponentFixture<ClienteDetallesComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ClienteDetallesComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ClienteDetallesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
