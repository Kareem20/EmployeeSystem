import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Employee } from '../models/Employee';
import { EmployeeToSent } from '../models/EmployeeToSent';

@Injectable({
  providedIn: 'root',
})
export class EmployeeService {
  private baseURL = 'https://localhost:7076/api';
  http = inject(HttpClient);
  getEmployees(): Observable<Employee[]> {
    return this.http.get<Employee[]>(`${this.baseURL}/employee`);
  }
  getEmployeeById(id: number): Observable<Employee> {
    return this.http.get<Employee>(`${this.baseURL}/employee/${id}`);
  }
  addEmployee(employee: EmployeeToSent) {
    return this.http.post(`${this.baseURL}/employee`, employee);
  }
  updateEmployee(id: number, employee: Employee) {
    return this.http.put(`${this.baseURL}/employee/${id}`, employee);
  }
  deleteEmployee(id: number) {
    return this.http.delete(`${this.baseURL}/employee/${id}`);
  }
  getTotalEmployeeSalary(): Observable<number> {
    return this.http.get<number>(`${this.baseURL}/Employee/salaries/total`);
  }
  getGenders() {
    return this.http.get(`${this.baseURL}/gender`);
  }
  getDepartments() {
    return this.http.get(`${this.baseURL}/department`);
  }
}
