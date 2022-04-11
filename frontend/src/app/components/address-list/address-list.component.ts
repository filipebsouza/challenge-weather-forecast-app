import {Component, Input} from '@angular/core';
import {ApiLocationAddressResponseModel} from "../../services/http-services/responses/api-location-address-response.model";
import {LocalStorageService} from "../../services/browser-services/local-storage/local-storage.service";
import {LocalStorageKeysModel} from "../../services/browser-services/local-storage/local-storage-keys.model";
import {LocationModel} from "../../models/location.model";

@Component({
  selector: 'app-address-list',
  templateUrl: './address-list.component.html',
  styleUrls: ['./address-list.component.css']
})
export class AddressListComponent {

  @Input() address?: ApiLocationAddressResponseModel[];

  constructor(private localStorageService: LocalStorageService) {
  }

  select(address: ApiLocationAddressResponseModel) {
    this.localStorageService.set(LocalStorageKeysModel.location, JSON.stringify(address));
  }
}
