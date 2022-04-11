import { ComponentFixture, TestBed } from '@angular/core/testing';

import { WeatherForecastContainerComponent } from './weather-forecast-container.component';

describe('WeatherContainerComponent', () => {
  let component: WeatherForecastContainerComponent;
  let fixture: ComponentFixture<WeatherForecastContainerComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ WeatherForecastContainerComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(WeatherForecastContainerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
