import {NgModule} from '@angular/core';
import {CommonModule} from '@angular/common';
import {LocationService} from "./browser-services/location/location.service";
import {GenericApiService} from "./http-services/generic-api.service";
import {HttpClientModule} from "@angular/common/http";

const browserServices = [
  LocationService
];

const httpServices = [
  GenericApiService
]

@NgModule({
  imports: [
    CommonModule,
    HttpClientModule
  ],
  providers: [
    browserServices,
    httpServices
  ]
})
export class ServicesModule {
}
