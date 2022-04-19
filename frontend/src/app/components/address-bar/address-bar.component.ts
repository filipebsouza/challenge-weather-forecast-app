import {Component, Inject, OnInit} from '@angular/core';
import {GenericApiService} from "../../services/http-services/generic-api.service";
import {ApiLocationResponseModel} from "../../services/http-services/responses/api-location-response.model";
import {AddressPublisherService} from "../../services/events/address-publisher/address-publisher.service";

@Component({
  selector: 'app-address-bar',
  templateUrl: './address-bar.component.html',
  styleUrls: ['./address-bar.component.css']
})
export class AddressBarComponent implements OnInit {
  address: string = '';
  response?: ApiLocationResponseModel;

  constructor(@Inject('LOCATION_SERVICE_HOST') private locationApiHost: string,
              private apiService: GenericApiService, private addressPublisherService: AddressPublisherService) {
  }

  ngOnInit(): void {

  }

  search(): void {
    if (this.address) {
      this.apiService.get<ApiLocationResponseModel>(`${this.locationApiHost}/location?address=${this.address}`)
        .subscribe({
          next: (location => {
            this.response = location;
            this.response.errorMessage = undefined;
            this.addressPublisherService.create(this.response);
          }),
          error: (() => {
            let error = new ApiLocationResponseModel();
            error.errorMessage = `Address "${this.address}" not found!`;
            this.addressPublisherService.create(error);
          })
        });
    }
  }
}
