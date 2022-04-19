import {ApiLocationAddressResponseModel} from "./api-location-address-response.model";

export class ApiLocationResponseModel {
  errorMessage?: string;
  addresses?: ApiLocationAddressResponseModel[];
}
