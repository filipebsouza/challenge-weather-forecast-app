import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {TemperaturePipe} from "./temperature.pipe";

@NgModule({
  declarations: [
    TemperaturePipe
  ],
  imports: [
    CommonModule
  ],
  exports: [
    TemperaturePipe
  ]
})
export class PipesModule { }
