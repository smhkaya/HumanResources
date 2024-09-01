import { Component, OnDestroy, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { EmployeeService } from '../services/employee.service';
import { Employee } from '../models/employee.model';

@Component({
  selector: 'app-employee-list',
  templateUrl: './employee-list.component.html',
  styleUrls: ['./employee-list.component.css']
})
export class EmployeeListComponent implements OnInit, OnDestroy {
  
  employees$ = this.employeeService.getAllEmployees();
  deleteEmployeeSubscription?: Subscription;

  constructor(private employeeService: EmployeeService, private router: Router) { }

  ngOnInit(): void { }

  onDelete(id: string): void {
    if (confirm('Are you sure you want to delete this employee?')) {
      this.deleteEmployeeSubscription = this.employeeService.deleteEmployee(id)
        .subscribe({
          next: () => {
            // Refresh the list after deletion
            this.employees$ = this.employeeService.getAllEmployees();
          },
          error: (err) => {
            console.error('Error deleting employee:', err);
          }
        });
    }
  }

  ngOnDestroy(): void {
    this.deleteEmployeeSubscription?.unsubscribe();
  }
}
