import {Component, EventEmitter, OnInit, Output} from '@angular/core';

@Component({
  selector: 'app-weather-forecast-temperature-unit',
  templateUrl: './weather-forecast-temperature-unit.component.html',
  styleUrls: ['./weather-forecast-temperature-unit.component.css']
})
export class WeatherForecastTemperatureUnitComponent implements OnInit {
  temperatureUnit: string = 'C';
  @Output() selectTemperatureUnit = new EventEmitter<string>();

  constructor() {
  }

  ngOnInit(): void {
  }

  changeTemperatureUnit($event: any) {
    this.temperatureUnit = $event;
    this.selectTemperatureUnit.emit(this.temperatureUnit);
  }
}
