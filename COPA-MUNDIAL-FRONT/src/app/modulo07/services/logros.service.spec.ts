import { TestBed, inject } from '@angular/core/testing';

import { LogrosService } from './logros.service';

describe('LogrosService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [LogrosService]
    });
  });

  it('should be created', inject([LogrosService], (service: LogrosService) => {
    expect(service).toBeTruthy();
  }));
});
