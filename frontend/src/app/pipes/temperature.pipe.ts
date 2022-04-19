import {Pipe, PipeTransform} from '@angular/core';

@Pipe({
  name: 'temperature'
})
export class TemperaturePipe implements PipeTransform {

  transform(value: number, unit: string): string {
    return `${value}º${unit}`;
  }
}
