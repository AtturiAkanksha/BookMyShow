import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SeatingLayoutComponent } from './seating-layout.component';

describe('TheatreComponent', () => {
  let component: SeatingLayoutComponent;
  let fixture: ComponentFixture<SeatingLayoutComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [SeatingLayoutComponent]
    });
    fixture = TestBed.createComponent(SeatingLayoutComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
