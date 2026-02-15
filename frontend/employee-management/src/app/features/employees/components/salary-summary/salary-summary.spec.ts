import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SalarySummary } from './salary-summary';

describe('SalarySummary', () => {
  let component: SalarySummary;
  let fixture: ComponentFixture<SalarySummary>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [SalarySummary]
    })
    .compileComponents();

    fixture = TestBed.createComponent(SalarySummary);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
