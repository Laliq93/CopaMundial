import { TestBed, inject } from '@angular/core/testing';

import { Api08Service } from './api08.service';

describe('Api08Service', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [Api08Service]
    });
  });

  it('should be created', inject([Api08Service], (service: Api08Service) => {
    expect(service).toBeTruthy();
  }));
});
