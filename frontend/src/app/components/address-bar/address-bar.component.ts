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
