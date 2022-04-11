import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddressContainerComponent } from './address-container.component';

describe('AddressContainerComponent', () => {
  let component: AddressContainerComponent;
  let fixture: ComponentFixture<AddressContainerComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddressContainerComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AddressContainerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
