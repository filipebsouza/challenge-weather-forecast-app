import {Component, Inject, OnInit} from '@angular/core';
import {LocalStorageService} from "../../services/browser-services/local-storage/local-storage.service";
import {LocationService} from "../../services/browser-services/location/location.service";
import {GenericApiService} from "../../services/http-services/generic-api.service";
import {LocalStorageKeysModel} from "../../services/browser-services/local-storage/local-storage-keys.model";
import {LOCATION_SERVICE_HOST} from "../../services/_configs/providers";
import {BrowserLocationModel} from "../../services/browser-services/location/browser-location.model";
import {LocationPublisherService} from "../../services/events/location-publisher/location-publisher.service";

@Component({
  selector: 'app-browser-location',
  templateUrl: './browser-location.component.html',
  styleUrls: ['./browser-location.component.css']
})
export class BrowserLocationComponent implements OnInit {
  location?: BrowserLocationModel;

  constructor(private localStorageService: LocalStorageService, private locationService: LocationService,
              @Inject(LOCATION_SERVICE_HOST) private locationApiHost: string, private apiService: GenericApiService,
              private locationPublisherService: LocationPublisherService) {
  }

  ngOnInit(): void {
    this.location = this.localStorageService.get<BrowserLocationModel>(LocalStorageKeysModel.location);
    this.getLocation();
  }

  getLocation() {
    if (!this.location) {
      this.locationService.getLocation()
        .subscribe(location => {
          this.location = location;
          this.localStorageService.set(LocalStorageKeysModel.location, JSON.stringify(location));
          this.getAddress();
        });

      return;
    }

    this.getAddress();
  }

  getAddress() {
    const {latitude, longitude} = this.location!;
    this.apiService
      .getTeste(`${this.locationApiHost}/location/address?latitude=${latitude}&longitude=${longitude}`)
      //.get<string>(`${this.locationApiHost}/location/address?latitude=${latitude}&longitude=${longitude}`)
      .subscribe(address => {
        this.location!.setCompleteAddress(address);
        this.locationPublisherService.create(this.location!);
      });
  }
}
