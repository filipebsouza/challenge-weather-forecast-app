import { ComponentFixture, TestBed } from '@angular/core/testing';

import { WeatherForecastItemComponent } from './weather-forecast-item.component';

describe('WeatherForecastItemComponent', () => {
  let component: WeatherForecastItemComponent;
  let fixture: ComponentFixture<WeatherForecastItemComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ WeatherForecastItemComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(WeatherForecastItemComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
