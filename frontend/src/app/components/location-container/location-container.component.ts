import {Component} from '@angular/core';

@Component({
  selector: 'app-location-container',
  templateUrl: './location-container.component.html',
  styleUrls: ['./location-container.component.css']
})
export class LocationContainerComponent {
  locationType: string = 'address';

  isBrowserLocation(): boolean {
    return this.locationType == 'browser-location';
  }

  isAddressLocation() {
    return this.locationType == 'address';
  }

  changeLocationType($event: any) {
    this.locationType = $event;
  }
}
