import { TestBed } from '@angular/core/testing';

import { LocationPublisherService } from './location-publisher.service';

describe('LocationPublisherService', () => {
  let service: LocationPublisherService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(LocationPublisherService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
