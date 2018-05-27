import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ClientePartidoComponent } from './cliente-partido.component';

describe('ClientePartidoComponent', () => {
  let component: ClientePartidoComponent;
  let fixture: ComponentFixture<ClientePartidoComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ClientePartidoComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ClientePartidoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
