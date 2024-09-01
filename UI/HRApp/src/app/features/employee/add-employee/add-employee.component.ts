import { Component } from '@angular/core';
import { AddEmployee } from '../models/add-employee.model';
import { EmployeeService } from '../services/employee.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-add-employee',
  templateUrl: './add-employee.component.html',
  styleUrls: ['./add-employee.component.css']
})
export class AddEmployeeComponent {
  model: AddEmployee;

  constructor(private employeeService : EmployeeService,
    private router: Router
  ) 
  {
    this.model = {
      firstName: '',
      lastName: '',
      email: '',
      phoneNumber: '',
      hireDate: new Date(),
      jobTitle: '',
      salary: 0
    }
  }

  onFormSubmit(): void {
    this.employeeService.createEmployee(this.model)
    .subscribe({
      next: (response) => {
        this.router.navigateByUrl('/admin/employees')
      }
    });
  }
}
