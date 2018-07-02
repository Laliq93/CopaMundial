import { TestBed, inject } from '@angular/core/testing';

import { Partido.ServiceService } from './partido.service.service';

describe('Partido.ServiceService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [Partido.ServiceService]
    });
  });

  it('should be created', inject([Partido.ServiceService], (service: Partido.ServiceService) => {
    expect(service).toBeTruthy();
  }));
});
