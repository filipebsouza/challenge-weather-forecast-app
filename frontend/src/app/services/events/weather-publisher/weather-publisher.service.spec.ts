import { TestBed } from '@angular/core/testing';

import { WeatherPublisherService } from './weather-publisher.service';

describe('WeatherPublisherService', () => {
  let service: WeatherPublisherService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(WeatherPublisherService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
