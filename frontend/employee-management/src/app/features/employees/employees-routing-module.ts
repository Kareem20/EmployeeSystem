import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { EmployeeList } from './components/employee-list/employee-list';
import { EmployeeForm } from './components/employee-form/employee-form';
import { SalarySummary } from './components/salary-summary/salary-summary';
import { EmployeesLayout } from './components/employees-layout/employees-layout';

const routes: Routes = [
  {
    path: '',
    component: EmployeesLayout,
    children: [
      { path: '', component: EmployeeList },
      { path: 'add', component: EmployeeForm },
      { path: 'edit/:id', component: EmployeeForm },
      { path: 'summary', component: SalarySummary },
      { path: '', redirectTo: 'list', pathMatch: 'full' },
    ],
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class EmployeesRoutingModule {}
