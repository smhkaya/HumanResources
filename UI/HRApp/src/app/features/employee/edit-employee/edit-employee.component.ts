import { Component, OnDestroy, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { EmployeeService } from '../services/employee.service';
import { Employee } from '../models/employee.model';
import { UpdateEmployeeRequest } from '../models/update-employee-request.model';

@Component({
  selector: 'app-edit-employee',
  templateUrl: './edit-employee.component.html',
  styleUrls: ['./edit-employee.component.css']
})
export class EditEmployeeComponent implements OnInit, OnDestroy {

  id: string | null = null;
  paramsSubscription?: Subscription;
  editEmployeeSubscription?: Subscription;
  employee?: Employee;

  constructor(
    private route: ActivatedRoute,
    private employeeService: EmployeeService,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.paramsSubscription = this.route.paramMap.subscribe({
      next: (params) => {
        this.id = params.get('id');

        if (this.id) {
          this.employeeService.getEmployeeById(this.id).subscribe({
            next: (response) => {
              this.employee = response;
            }
          });
        }
      }
    });
  }

  onFormSubmit(): void {
    const updateEmployeeRequest: UpdateEmployeeRequest = {
      firstName: this.employee?.firstName ?? '',
      lastName: this.employee?.lastName ?? '',
      email: this.employee?.email ?? '',
      phoneNumber: this.employee?.phoneNumber ?? '',
      hireDate: this.employee?.hireDate ?? new Date(),
      jobTitle: this.employee?.jobTitle ?? '',
      salary: this.employee?.salary ?? 0
    };

    if (this.id) {
      this.editEmployeeSubscription = this.employeeService.updateEmployee(this.id, updateEmployeeRequest)
        .subscribe({
          next: (response) => {
            this.router.navigateByUrl('/admin/employees');
          }
        });
    }
  }

  onDelete(): void {
    if (this.id) {
      this.employeeService.deleteEmployee(this.id).subscribe({
        next: (response) => {
          this.router.navigateByUrl('/admin/employees');
        }
      });
    }
  }

  ngOnDestroy(): void {
    this.paramsSubscription?.unsubscribe();
    this.editEmployeeSubscription?.unsubscribe();
  }
}
