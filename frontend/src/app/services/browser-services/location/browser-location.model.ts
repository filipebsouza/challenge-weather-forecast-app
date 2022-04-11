import {BrowserLocationState} from "./browser-location-state.model";
import {LocationModel} from "../../../models/location.model";

export class BrowserLocationModel implements LocationModel{
  latitude?: number;
  longitude?: number;
  completeAddress?: string;
  state: BrowserLocationState;

  constructor(latitude?: number, longitude?: number, state = BrowserLocationState.Success) {
    this.latitude = latitude;
    this.longitude = longitude;
    this.state = state;
  }

  getLatitude(): number | undefined {
    return this.latitude;
  }

  getLongitude(): number | undefined {
    return this.longitude;
  }

  getCompleteAddress(): string | undefined {
    return this.completeAddress;
  }

  setCompleteAddress(completeAddress: string): void {
    this.completeAddress = completeAddress;
  }

  hasSuccess(): boolean {
    return this.state == BrowserLocationState.Success;
  }
}
