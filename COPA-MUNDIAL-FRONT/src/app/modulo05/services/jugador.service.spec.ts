import { TestBed, inject } from '@angular/core/testing';

import { JugadorService } from './jugador.service';

describe('JugadorService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [JugadorService]
    });
  });

  it('should be created', inject([JugadorService], (service: JugadorService) => {
    expect(service).toBeTruthy();
  }));
});
