import {Component, Inject, OnDestroy, OnInit} from '@angular/core';
import {LocationModel} from "../../models/location.model";
import {GenericApiService} from "../../services/http-services/generic-api.service";
import {LocationPublisherService} from "../../services/events/location-publisher/location-publisher.service";
import {
  ApiWeatherForecastResponseModel
} from "../../services/http-services/responses/api-weather-forecast-response.model";
import {Subscription} from "rxjs";
import {WeatherPublisherService} from "../../services/events/weather-publisher/weather-publisher.service";

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
              private locationPublisherService: LocationPublisherService, private weatherPublisherService: WeatherPublisherService) {
  }

  ngOnInit(): void {
    this.observer = this.locationPublisherService.emitter.subscribe(location => {
      this.location = location;
      this.getWeatherForecast();
    })
  }

  selectTemperatureUnit(temperatureUnit: string): void {
    this.temperatureUnit = temperatureUnit;
    this.getWeatherForecast();
  }

  getWeatherForecast(): void {
    this.apiService
      .get<ApiWeatherForecastResponseModel>(`${this.weatherApiHost}/forecast?latitude=${this.location.latitude}&longitude=${this.location.longitude}&temperatureUnit=${this.temperatureUnit}`)
      .subscribe({
        next: response => this.weatherPublisherService.create(response),
        error: (() => {
          let error = new ApiWeatherForecastResponseModel();
          error.errorMessage = `Weather forecast for latitude "${this.location.latitude}" and longitude ${this.location.longitude} not found!`;
          this.weatherPublisherService.create(error);
        })
      });
  }

  ngOnDestroy(): void {
    this.observer.unsubscribe();
  }
}
