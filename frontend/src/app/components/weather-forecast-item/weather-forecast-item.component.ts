import {Component, Input, OnInit} from '@angular/core';
import {
  ApiWeatherForecastByDayResponseModel
} from "../../services/http-services/responses/api-weather-forecast-by-day-response.model";

@Component({
  selector: 'app-weather-forecast-item',
  templateUrl: './weather-forecast-item.component.html',
  styleUrls: ['./weather-forecast-item.component.css']
})
export class WeatherForecastItemComponent {
  @Input() item: ApiWeatherForecastByDayResponseModel | undefined;
}
