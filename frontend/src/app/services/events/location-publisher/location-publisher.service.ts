import { Injectable } from '@angular/core';
import {Subject} from "rxjs";
import {LocationModel} from "../../../models/location.model";

@Injectable({
  providedIn: 'root'
})
export class LocationPublisherService {
  private _emitter: Subject<LocationModel> = new Subject<LocationModel>();

  public create(location: LocationModel) {
    this._emitter.next(location);
  }

  get emitter(): Subject<LocationModel> {
    return this._emitter;
  }
}
