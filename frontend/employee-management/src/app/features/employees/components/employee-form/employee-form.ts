import { Component, inject, OnInit, signal } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { Gender } from '../../models/Gender';
import { Department } from '../../models/Department';
import { EmployeeService } from '../../services/employee';
import { CommonModule } from '@angular/common';
import { Router, ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-employee-form',
  imports: [CommonModule, ReactiveFormsModule],
  templateUrl: './employee-form.html',
  styleUrl: './employee-form.css',
})
export class EmployeeForm implements OnInit {
  private router = inject(Router);
  private employeeService = inject(EmployeeService);
  private route = inject(ActivatedRoute);
  formBuilder = inject(FormBuilder);
  employeeForm!: FormGroup;
  genders = signal<Gender[]>([]);
  departments = signal<Department[]>([]);
  loading = false;
  isEditableMode = false;
  employeeId!: number;
  ngOnInit(): void {
    this.loadDropdownData();
    this.buildForm();
    const id = this.route.snapshot.paramMap.get('id');
    if (id) {
      this.isEditableMode = true;
      this.employeeId = +id;
      this.employeeService.getEmployeeById(this.employeeId).subscribe({
        next: (data) => {
          this.employeeForm.patchValue(data);
        },
      });
    } 
  }

  buildForm() {
    this.employeeForm = this.formBuilder.group({
      name: ['', Validators.required],
      address: ['', Validators.required],
      genderId: ['', Validators.required],
      jobTitle: ['', Validators.required],
      salary: ['', [Validators.required, Validators.min(100)]],
      departmentId: ['', Validators.required],
      genderName:[''],
      departmentName:['']
    });
  }

  loadDropdownData() {
    this.employeeService.getGenders().subscribe({
      next: (data) => {
        this.genders.set(data as Gender[]);
      },
    });
    this.employeeService.getDepartments().subscribe({
      next: (data) => {
        this.departments.set(data as Department[]);
      },
    });
  }

  onSubmit() {
    if (this.employeeForm.invalid) return;
    const employeeData = this.employeeForm.value;
    const employee = {
      employeeId: this.employeeId,
      name: employeeData.name,
      address: employeeData.address,
      genderId: employeeData.genderId,
      genderName: employeeData.genderName,
      jobTitle: employeeData.jobTitle,
      salary: employeeData.salary,
      departmentId: employeeData.departmentId,
      departmentName: employeeData.departmentName,
    };
    this.loading = true;
    if (this.isEditableMode) {
      this.employeeService.updateEmployee(this.employeeId, employee).subscribe({
        next: () => {
          this.router.navigate(['/employees']);
        },
        error:()=>{
          this.loading = false;         
           alert('Error Updating employee');
        }
      });
    } else {
      this.employeeService.addEmployee(employee).subscribe({
        next: () => {
          this.router.navigate(['/employees']);
          this.employeeForm.reset();
          this.loading = false;
        },
        error: () => {
          this.loading = false;
          alert('Error adding employee');
        },
      });
    }
  }
}
