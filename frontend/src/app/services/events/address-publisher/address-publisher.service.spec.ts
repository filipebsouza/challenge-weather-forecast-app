import { TestBed } from '@angular/core/testing';

import { AddressPublisherService } from './address-publisher.service';

describe('AddressPublisherService', () => {
  let service: AddressPublisherService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(AddressPublisherService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
