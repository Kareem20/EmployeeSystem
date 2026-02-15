import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EmployeesLayout } from './employees-layout';

describe('EmployeesLayout', () => {
  let component: EmployeesLayout;
  let fixture: ComponentFixture<EmployeesLayout>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [EmployeesLayout]
    })
    .compileComponents();

    fixture = TestBed.createComponent(EmployeesLayout);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
