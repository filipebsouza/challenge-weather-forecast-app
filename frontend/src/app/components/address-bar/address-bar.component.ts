import {Component, Inject, OnInit} from '@angular/core';
import {LocalStorageService} from "../../services/browser-services/local-storage/local-storage.service";
import {LocationService} from "../../services/browser-services/location/location.service";
import {LocalStorageKeysModel} from "../../services/browser-services/local-storage/local-storage-keys.model";
import {Observable} from "rxjs";
import {BrowserLocationModel} from "../../services/browser-services/location/browser-location.model";
import {GenericApiService} from "../../services/http-services/generic-api.service";
import {ApiLocationResponseModel} from "../../services/http-services/responses/api-location-response.model";

@Component({
  selector: 'app-address-bar',
  templateUrl: './address-bar.component.html',
  styleUrls: ['./address-bar.component.css']
})
export class AddressBarComponent implements OnInit {

  address: string = '';
  browserLocation?: BrowserLocationModel;

  constructor(private localStorageService: LocalStorageService, private locationService: LocationService,
              @Inject('LOCATION_SERVICE_HOST') public locationApiHost: string, private apiService: GenericApiService) {
  }

  ngOnInit(): void {
    new Observable<void>(observable => {
      this.locationService.getLocation()
        .subscribe(location => {
          this.browserLocation = location;
          this.localStorageService.set(LocalStorageKeysModel.location, JSON.stringify(location));
        });
    });
  }

  search() {
    if (this.address) {
      this.apiService.get<ApiLocationResponseModel>(`${this.locationApiHost}?address=${this.address}`)
        .subscribe(location => {

        });
    }
  }

}
