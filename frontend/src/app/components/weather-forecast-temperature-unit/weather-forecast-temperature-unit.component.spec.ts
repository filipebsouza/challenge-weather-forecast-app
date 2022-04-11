import { ComponentFixture, TestBed } from '@angular/core/testing';

import { WeatherForecastTemperatureUnitComponent } from './weather-forecast-temperature-unit.component';

describe('WeatherTypeComponent', () => {
  let component: WeatherForecastTemperatureUnitComponent;
  let fixture: ComponentFixture<WeatherForecastTemperatureUnitComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ WeatherForecastTemperatureUnitComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(WeatherForecastTemperatureUnitComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
