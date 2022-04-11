import {LocationModel} from "../../../models/location.model";

export class ApiLocationAddressResponseModel implements LocationModel {
  latitude!: number;
  longitude!: number;
  completeAddress!: string;

  getLatitude(): number | undefined {
    return this.latitude;
  }

  getLongitude(): number | undefined {
    return this.longitude;
  }

  isValid(): boolean {
    return !!this.latitude && !!this.longitude;
  }

  getCompleteAddress(): string | undefined {
    return this.completeAddress;
  }
}
