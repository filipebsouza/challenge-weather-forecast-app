import {NgModule} from '@angular/core';
import {CommonModule} from '@angular/common';
import {LocalStorageService} from "./browser-services/local-storage/local-storage.service";
import {LocationService} from "./browser-services/location/location.service";
import {GenericApiService} from "./http-services/generic-api.service";

const browserServices = [
  LocalStorageService,
  LocationService
];

const httpServices = [
  GenericApiService
]

@NgModule({
  imports: [
    CommonModule
  ],
  providers: [
    browserServices,
    httpServices
  ]
})
export class ServicesModule {
}
