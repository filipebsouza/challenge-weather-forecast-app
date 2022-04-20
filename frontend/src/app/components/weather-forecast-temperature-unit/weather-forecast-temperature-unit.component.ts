import {Component, EventEmitter, Output} from '@angular/core';

@Component({
  selector: 'app-weather-forecast-temperature-unit',
  templateUrl: './weather-forecast-temperature-unit.component.html'
})
export class WeatherForecastTemperatureUnitComponent {
  temperatureUnit: string = 'C';
  @Output() selectTemperatureUnit = new EventEmitter<string>();

  changeTemperatureUnit($event: any) {
    this.temperatureUnit = $event;
    this.selectTemperatureUnit.emit(this.temperatureUnit);
  }
}
