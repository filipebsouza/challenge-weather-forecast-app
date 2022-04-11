import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BrowserLocationComponent } from './browser-location.component';

describe('BrowserLocationComponent', () => {
  let component: BrowserLocationComponent;
  let fixture: ComponentFixture<BrowserLocationComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ BrowserLocationComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(BrowserLocationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
