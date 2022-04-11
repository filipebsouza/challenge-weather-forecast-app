import {Injectable} from '@angular/core';
import {BrowserLocationModel} from "./browser-location.model";
import {Observable} from "rxjs";
import {BrowserLocationState} from "./browser-location-state.model";

@Injectable({
  providedIn: 'root'
})
export class LocationService {

  getLocation(): Observable<BrowserLocationModel> {
    return new Observable<BrowserLocationModel>(observable => {
      navigator.geolocation?.getCurrentPosition(
        success => {
          observable.next(new BrowserLocationModel(success.coords.latitude, success.coords.longitude));
          observable.complete();
        },
        error => {
          let locationStateError = BrowserLocationState.UnexpectedError;
          if (error.PERMISSION_DENIED) {
            locationStateError = BrowserLocationState.PermissionDenied;
          } else if (error.POSITION_UNAVAILABLE) {
            locationStateError = BrowserLocationState.PositionUnavailable;
          } else if (error.TIMEOUT) {
            locationStateError = BrowserLocationState.Timeout;
          }
          observable.next(new BrowserLocationModel(locationStateError));
          observable.complete();
        }
      );
    });
  }
}
