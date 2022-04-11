import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {AppComponent} from "../app.component";
import {AddressBarComponent} from "./address-bar/address-bar.component";
import {AddressListComponent} from "./address-list/address-list.component";
import {WeatherForecastContainerComponent} from "./weather-forecast-container/weather-forecast-container.component";
import {WeatherForecastTemperatureUnitComponent} from "./weather-forecast-temperature-unit/weather-forecast-temperature-unit.component";
import {AddressContainerComponent} from "./address-container/address-container.component";
import {WeatherForecastListComponent} from "./weather-forecast-list/weather-forecast-list.component";
import {WeatherForecastItemComponent} from "./weather-forecast-item/weather-forecast-item.component";
import {BrowserLocationComponent} from "./browser-location/browser-location.component";
import {WeatherForecastPageComponent} from "../pages/weather-page/weather-forecast-page.component";
import {LocationContainerComponent} from "./location-container/location-container.component";
import {FormsModule} from "@angular/forms";

const components = [
  AppComponent,
  AddressBarComponent,
  AddressListComponent,
  WeatherForecastContainerComponent,
  WeatherForecastTemperatureUnitComponent,
  AddressContainerComponent,
  WeatherForecastListComponent,
  WeatherForecastItemComponent,
  BrowserLocationComponent,
  WeatherForecastPageComponent,
  LocationContainerComponent
];

@NgModule({
  declarations: [components],
  imports: [
    CommonModule,
    FormsModule
  ],
  exports: [
    components
  ]
})
export class ComponentsModule { }
