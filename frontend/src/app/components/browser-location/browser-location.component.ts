import {Component, Inject, OnInit} from '@angular/core';
import {LocationService} from "../../services/browser-services/location/location.service";
import {GenericApiService} from "../../services/http-services/generic-api.service";
import {LOCATION_SERVICE_HOST} from "../../services/_configs/providers";
import {BrowserLocationModel} from "../../services/browser-services/location/browser-location.model";
import {LocationPublisherService} from "../../services/events/location-publisher/location-publisher.service";

@Component({
  selector: 'app-browser-location',
  templateUrl: './browser-location.component.html'
})
export class BrowserLocationComponent implements OnInit {
  location?: BrowserLocationModel;

  constructor(private locationService: LocationService, @Inject(LOCATION_SERVICE_HOST) private locationApiHost: string,
              private apiService: GenericApiService, private locationPublisherService: LocationPublisherService) {
  }

  ngOnInit(): void {
    this.getLocation();
  }

  getLocation() {
    if (!this.location || !this.location.isValid()) {
      this.locationService.getLocation()
        .subscribe(location => {
          this.location = location;
          this.getAddress();
        });

      return;
    }

    this.getAddress();
  }

  getAddress() {
    if (!this.location?.isValid()) {
      return;
    }

    this.locationPublisherService.create(this.location!);
  }
}
