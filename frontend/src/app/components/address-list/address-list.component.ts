import {Component, Input, OnDestroy, OnInit} from '@angular/core';
import {
  ApiLocationAddressResponseModel
} from "../../services/http-services/responses/api-location-address-response.model";
import {LocalStorageService} from "../../services/browser-services/local-storage/local-storage.service";
import {LocalStorageKeysModel} from "../../services/browser-services/local-storage/local-storage-keys.model";
import {AddressPublisherService} from "../../services/events/address-publisher/address-publisher.service";
import {Subscription} from "rxjs";
import {LocationPublisherService} from "../../services/events/location-publisher/location-publisher.service";

@Component({
  selector: 'app-address-list',
  templateUrl: './address-list.component.html',
  styleUrls: ['./address-list.component.css']
})
export class AddressListComponent implements OnInit, OnDestroy {
  addresses?: ApiLocationAddressResponseModel[];
  observer = new Subscription();

  constructor(private addressPublisherService: AddressPublisherService, private localStorageService: LocalStorageService,
              private locationPublisherService: LocationPublisherService) {
  }

  ngOnInit(): void {
    this.observer = this.addressPublisherService.emitter.subscribe(response => {
      this.addresses = response.addresses;
    });
  }

  select(address: ApiLocationAddressResponseModel) {
    this.localStorageService.set(LocalStorageKeysModel.location, JSON.stringify(address));
    this.locationPublisherService.create(address);
  }

  ngOnDestroy(): void {
    this.observer.unsubscribe();
  }
}
