import { TestBed } from '@angular/core/testing';

import { RRApiService } from './rrapi.service';

describe('RRApiService', () => {
  let service: RRApiService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(RRApiService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
