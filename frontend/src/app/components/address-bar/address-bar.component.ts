import {Component, Inject, OnInit} from '@angular/core';
import {LocalStorageService} from "../../services/browser-services/local-storage/local-storage.service";
import {LocationService} from "../../services/browser-services/location/location.service";
import {LocalStorageKeysModel} from "../../services/browser-services/local-storage/local-storage-keys.model";
import {Observable} from "rxjs";
import {BrowserLocationModel} from "../../services/browser-services/location/browser-location.model";
import {GenericApiService} from "../../services/http-services/generic-api.service";
import {ApiLocationResponseModel} from "../../services/http-services/responses/api-location-response.model";
import {LocationPublisherService} from "../../services/events/location-publisher/location-publisher.service";
import {AddressPublisherService} from "../../services/events/address-publisher/address-publisher.service";

@Component({
  selector: 'app-address-bar',
  templateUrl: './address-bar.component.html',
  styleUrls: ['./address-bar.component.css']
})
export class AddressBarComponent implements OnInit {
  address: string = '';
  response?: ApiLocationResponseModel;

  constructor(private localStorageService: LocalStorageService, @Inject('LOCATION_SERVICE_HOST') private locationApiHost: string,
              private apiService: GenericApiService, private addressPublisherService: AddressPublisherService) {
  }

  ngOnInit(): void {

  }

  search() {
    if (this.address) {
      //this.apiService.get<ApiLocationResponseModel>(`${this.locationApiHost}?address=${this.address}`)
      this.apiService.getTeste2(`${this.locationApiHost}?address=${this.address}`)
        .subscribe(location => {
          this.response = location;
          this.addressPublisherService.create(this.response);
        });
    }
  }
}
