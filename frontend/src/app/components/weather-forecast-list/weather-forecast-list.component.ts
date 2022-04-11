import {Component, OnDestroy, OnInit} from '@angular/core';
import {WeatherPublisherService} from "../../services/events/weather-publisher/weather-publisher.service";
import {
  ApiWeatherForecastResponseModel
} from "../../services/http-services/responses/api-weather-forecast-response.model";
import {Subscription} from "rxjs";

@Component({
  selector: 'app-weather-forecast-list',
  templateUrl: './weather-forecast-list.component.html',
  styleUrls: ['./weather-forecast-list.component.css']
})
export class WeatherForecastListComponent implements OnInit, OnDestroy {
  weatherForecast?: ApiWeatherForecastResponseModel;
  observer: Subscription = new Subscription();
  constructor(private weatherPublisherService: WeatherPublisherService) { }

  ngOnInit(): void {
    this.observer = this.weatherPublisherService.emitter.subscribe(weatherForecast => {
      this.weatherForecast = weatherForecast;
    })
  }

  ngOnDestroy(): void {
    this.observer.unsubscribe();
  }

}
