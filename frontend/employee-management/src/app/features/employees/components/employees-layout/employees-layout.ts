import { Component } from '@angular/core';
import { EmployeesRoutingModule } from "../../employees-routing-module";
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';

@Component({
  selector: 'app-employees-layout',
  imports: [CommonModule,RouterModule],
  templateUrl: './employees-layout.html',
  styleUrl: './employees-layout.css',
})
export class EmployeesLayout {

}
