import {ApiWeatherForecastByDayResponseModel} from "./api-weather-forecast-by-day-response.model";

export class ApiWeatherForecastResponseModel {
  errorMessage?: string;
  days!: ApiWeatherForecastByDayResponseModel[];
}
