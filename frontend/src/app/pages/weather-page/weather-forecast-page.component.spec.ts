import { ComponentFixture, TestBed } from '@angular/core/testing';

import { WeatherForecastPageComponent } from './weather-forecast-page.component';

describe('WeatherPageComponent', () => {
  let component: WeatherForecastPageComponent;
  let fixture: ComponentFixture<WeatherForecastPageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ WeatherForecastPageComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(WeatherForecastPageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
