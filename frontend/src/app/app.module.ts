import {NgModule} from '@angular/core';
import {BrowserModule} from '@angular/platform-browser';

import {AppComponent} from './app.component';
import {ServicesModule} from "./services/services.module";
import {environment} from 'src/environments/environment';
import {FormsModule} from "@angular/forms";
import {ComponentsModule} from "./components/components.module";
import {LOCATION_SERVICE_HOST, WEATHER_SERVICE_HOST} from "./services/_configs/providers";


@NgModule({
  imports: [
    BrowserModule,
    ServicesModule,
    FormsModule,
    ComponentsModule
  ],
  providers: [
    {provide: LOCATION_SERVICE_HOST, useValue: environment.locationServiceHost},
    {provide: WEATHER_SERVICE_HOST, useValue: environment.weatherServiceHost},
  ],
  bootstrap: [AppComponent],
})
export class AppModule {
}
