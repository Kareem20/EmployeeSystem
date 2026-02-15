import { Routes } from '@angular/router';

export const routes: Routes = [
  {
    path: 'employees',
    loadChildren: () =>
      import('./features/employees/employees-module').then((m) => m.EmployeesModule),
  },
  { path: '', redirectTo: 'employees', pathMatch: 'full' },
];
