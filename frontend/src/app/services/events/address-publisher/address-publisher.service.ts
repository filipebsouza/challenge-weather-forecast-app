import {Injectable} from '@angular/core';
import {Subject} from "rxjs";
import {ApiLocationResponseModel} from "../../http-services/responses/api-location-response.model";

@Injectable({
  providedIn: 'root'
})
export class AddressPublisherService {
  private _emitter: Subject<ApiLocationResponseModel> = new Subject<ApiLocationResponseModel>();

  create(response: ApiLocationResponseModel) {
    this._emitter.next(response);
  }

  get emitter(): Subject<ApiLocationResponseModel> {
    return this._emitter;
  }
}
