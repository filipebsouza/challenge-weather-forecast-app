import {Component, Inject, OnDestroy, OnInit} from '@angular/core';
import {LocationModel} from "../../models/location.model";
import {GenericApiService} from "../../services/http-services/generic-api.service";
import {LocationPublisherService} from "../../services/events/location-publisher/location-publisher.service";
import {
  ApiWeatherForecastResponseModel
} from "../../services/http-services/responses/api-weather-forecast-response.model";
import {Subscription} from "rxjs";

@Component({
  selector: 'app-weather-forecast-container',
  templateUrl: './weather-forecast-container.component.html',
  styleUrls: ['./weather-forecast-container.component.css']
})
export class WeatherForecastContainerComponent implements OnInit, OnDestroy {
  location!: LocationModel
  temperatureUnit = 'C';
  observer: Subscription = new Subscription();

  constructor(private apiService: GenericApiService, @Inject('WEATHER_SERVICE_HOST') private weatherApiHost: string,
              private locationPublisherService: LocationPublisherService) {
  }

  ngOnInit(): void {
    this.observer = this.locationPublisherService.emitter.subscribe(location => {
      this.location = location;
      const {latitude, longitude} = this.location;
      this.apiService.get<ApiWeatherForecastResponseModel>(`${this.weatherApiHost}?latitude=${latitude}&longitude=${longitude}&unit=${this.temperatureUnit}`)
        .subscribe(response => {

        });
    })
  }

  selectTemperatureUnit(temperatureUnit: string): void {
    this.temperatureUnit = temperatureUnit;
  }

  ngOnDestroy(): void {
    this.observer.unsubscribe();
  }
}
