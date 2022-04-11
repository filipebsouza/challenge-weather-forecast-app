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

  hasSuccess(): boolean {
    return !!this.latitude && !!this.longitude;
  }
}
