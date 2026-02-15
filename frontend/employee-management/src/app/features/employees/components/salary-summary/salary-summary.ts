import { Component, inject, OnInit, signal } from '@angular/core';
import { EmployeeService } from '../../services/employee';

@Component({
  selector: 'app-salary-summary',
  templateUrl: './salary-summary.html',
  styleUrl: './salary-summary.css',
})
export class SalarySummary implements OnInit {
  employeeSerivce = inject(EmployeeService);
  SalarySummary = signal<any>(0);
  loading = false;
  error: string | null = null;
  ngOnInit(): void {
    this.loadSalarySummary();
  }
  loadSalarySummary() {
    this.loading = true;
    this.employeeSerivce.getTotalEmployeeSalary().subscribe({
      next: (data) => {
        this.SalarySummary.set(data);
        console.log(this.SalarySummary()['totalSalary']);
        this.loading = false;
      },
      error: (err) => {
        this.error = 'Failed to load Salary Summary.';
        this.loading = false;
        console.error(err);
      },
    });
  }
}
