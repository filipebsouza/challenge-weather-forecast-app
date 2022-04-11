import {Injectable} from '@angular/core';
import {Subject} from "rxjs";
import {ApiWeatherForecastResponseModel} from "../../http-services/responses/api-weather-forecast-response.model";

@Injectable({
  providedIn: 'root'
})
export class WeatherPublisherService {
  private _emitter: Subject<ApiWeatherForecastResponseModel> = new Subject<ApiWeatherForecastResponseModel>();

  public create(response: ApiWeatherForecastResponseModel) {
    this._emitter.next(response);
  }

  get emitter(): Subject<ApiWeatherForecastResponseModel> {
    return this._emitter;
  }
}
