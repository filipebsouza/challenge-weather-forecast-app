import {NgModule} from '@angular/core';
import {BrowserModule} from '@angular/platform-browser';

import {AppRoutingModule} from './routing/app-routing.module';
import {AppComponent} from './app.component';
import {AddressBarComponent} from './components/address-bar/address-bar.component';
import {ServicesModule} from "./services/services.module";
import {environment} from 'src/environments/environment';
import { AddressListComponent } from './components/address-list/address-list.component';
import {FormsModule} from "@angular/forms";

@NgModule({
  declarations: [
    AppComponent,
    AddressBarComponent,
    AddressListComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    ServicesModule,
    FormsModule
  ],
  providers: [
    {provide: 'LOCATION_SERVICE_HOST', useValue: environment.locationServiceHost},
    {provide: 'WEATHER_SERVICE_HOST', useValue: environment.weatherServiceHost},
  ],
  bootstrap: [AppComponent]
})
export class AppModule {
}
