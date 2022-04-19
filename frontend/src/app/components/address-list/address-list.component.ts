import {Component, Input, OnDestroy, OnInit} from '@angular/core';
import {
  ApiLocationAddressResponseModel
} from "../../services/http-services/responses/api-location-address-response.model";
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
  message = 'No address found!';
  observer = new Subscription();

  constructor(private addressPublisherService: AddressPublisherService, private locationPublisherService: LocationPublisherService) {
  }

  ngOnInit(): void {
    this.observer = this.addressPublisherService.emitter.subscribe(response => {
      if (response && !response.errorMessage) {
        this.addresses = response.addresses;
      } else {
        this.message = response.errorMessage!;
      }
    });
  }

  select(address: ApiLocationAddressResponseModel) {
    this.locationPublisherService.create(address);
  }

  ngOnDestroy(): void {
    this.observer.unsubscribe();
  }
}
