import { Component, inject, OnInit, signal } from '@angular/core';
import { Employee } from '../../models/Employee';
import { EmployeeService } from '../../services/employee';
import { RouterModule } from '@angular/router';

@Component({
  selector: 'app-employee-list',
  templateUrl: './employee-list.html',
  styleUrl: './employee-list.css',
  imports:[RouterModule],
})
export class EmployeeList implements OnInit {
  employees = signal<Employee[]>([]);
  employeeService = inject(EmployeeService);
  loading = false;
  error: string | null = null;
  ngOnInit(): void {
    this.loadEmployees();
  }
  loadEmployees() {
    this.loading = true;
    this.employeeService.getEmployees().subscribe({
      next: (data) => {
        this.employees.set(data);
        this.loading = false;
        console.log(this.employees());
      },
      error: (err) => {
        this.error = 'Failed to load employees';
        this.loading = false;
        console.error(err);
      },
    });
  }
  confirmDelete(id: number, name: string) {
    console.log(`Attempting to delete employee with ID: ${id}, Name: ${name}`);
    const confirmed = confirm(`Are you sure you want to delete ${name}?`);

    if (!confirmed) return;

    this.employeeService.deleteEmployee(id).subscribe({
      next: () => {
        this.loadEmployees(); // refresh list
      },
      error: (err) => {
        console.error(err);
      },
    });
  }
}
