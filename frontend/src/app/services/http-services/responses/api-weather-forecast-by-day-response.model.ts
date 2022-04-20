export class ApiWeatherForecastByDayResponseModel {
  date!: Date;
  temperatureUnit!: string;
  temperature!: number;
  image!: string;
  shortDescription!: string;
  description?: string;
  isDayTime: boolean = false;
}
