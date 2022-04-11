import {GenericApiContract} from "./generic-api-contract";
import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs";
import {Injectable} from "@angular/core";
import {ApiLocationResponseModel} from "./responses/api-location-response.model";
import {ApiLocationAddressResponseModel} from "./responses/api-location-address-response.model";
import {ApiWeatherForecastResponseModel} from "./responses/api-weather-forecast-response.model";
import {ApiWeatherForecastByDayResponseModel} from "./responses/api-weather-forecast-by-day-response.model";

@Injectable()
export class GenericApiService implements GenericApiContract {
  constructor(public http: HttpClient) {
  }

  get<ReturnType>(resource: string, ...args: any): Observable<ReturnType> {
    return this.http.get<ReturnType>(resource);
  }

  getTeste(resource: string, ...args: any): Observable<string> {
    return new Observable<string>(subscriber => {
      subscriber.next('4600 Silver Hill Rd, Washington, DC 20233');
      subscriber.complete();
    });
  }

  getTeste2(resource: string, ...args: any): Observable<ApiLocationResponseModel> {
    return new Observable<ApiLocationResponseModel>(subscriber => {
      let response = new ApiLocationResponseModel();
      let item = new ApiLocationAddressResponseModel();
      item.completeAddress = '4600 Silver Hill Rd, Washington, DC 20233';
      item.longitude = -76.92744;
      item.latitude = 38.845985;
      response.addresses = [item];
      subscriber.next(response);
      subscriber.complete();
    });
  }

  getTeste3(resource: string): Observable<ApiWeatherForecastResponseModel> {
    return new Observable<ApiWeatherForecastResponseModel>(subscriber => {
      let response = new ApiWeatherForecastResponseModel();
      let item = new ApiWeatherForecastByDayResponseModel();
      item.date = new Date();
      item.temperatureUnit = 'C';
      item.temperature = 25;
      item.image = 'https://api.weather.gov/icons/land/day/sct?size=small';
      item.shortDescription = 'Mostly Sunny';
      response.days = [item];
      subscriber.next(response);
      subscriber.complete();
    });
  }
}

//ApiLocationResponseModel


// let response = new LocationResponseModel();
// response.addresses = [{
//   completeAddress: '4600 Silver Hill Rd, Washington, DC 20233',
//   longitude: -76.92744,
//   latitude: 38.845985
// }]
