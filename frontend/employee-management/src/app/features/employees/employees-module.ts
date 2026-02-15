import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { EmployeesRoutingModule } from './employees-routing-module';
import { ReactiveFormsModule } from '@angular/forms';
import { EmployeesLayout } from './components/employees-layout/employees-layout';
import { EmployeeList } from './components/employee-list/employee-list';
import { SalarySummary } from './components/salary-summary/salary-summary';
import { EmployeeForm } from './components/employee-form/employee-form';


@NgModule({
  declarations: [
    
  ],
  imports: [
    CommonModule,
    ReactiveFormsModule,
    EmployeesRoutingModule,
    
    EmployeesLayout,
    EmployeeList,
    EmployeeForm,
    SalarySummary
  ]
})
export class EmployeesModule { }
