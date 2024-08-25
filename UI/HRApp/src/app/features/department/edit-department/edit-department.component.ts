import { Component, OnDestroy, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { DepartmentService } from '../services/department.service';
import { Department } from '../models/department.model';
import { UpdateDepartmentRequest } from '../models/update-department-request.model';

@Component({
  selector: 'app-edit-department',
  templateUrl: './edit-department.component.html',
  styleUrls: ['./edit-department.component.css']
})
export class EditDepartmentComponent implements OnInit, OnDestroy{

  id: string | null = null;
  paramsSubscription?: Subscription;
  editDepartmentSubscription?: Subscription;
  department?: Department;

  constructor(private route: ActivatedRoute,
    private departmentService: DepartmentService,
    private router:  Router )
  {
    
  }
  ngOnInit(): void {
    this.paramsSubscription = this.route.paramMap.subscribe({
      next: (params) => {
       this.id =  params.get('id');

       if(this.id){
        this.departmentService.getDepartmentById(this.id)
        .subscribe({
          next: (response) => {
            this.department = response;
          }
        })
       }

      }
    });
  }

  onFormSubmit(): void {
    const updateDepartmentRequest : UpdateDepartmentRequest = {
      name: this.department?.name ?? '',
      location: this.department?.location ?? ''
    };
    
    if(this.id ){
      this.editDepartmentSubscription = this.departmentService.updateDepartment(this.id, updateDepartmentRequest)
      .subscribe({
        next: (response) => {
          this.router.navigateByUrl('/admin/departments');
        }
      });

    }
  }

  onDelete(): void {
    if(this.id){
      this.departmentService.deleteDepartment(this.id)
      .subscribe({
        next: (response) => {
          this.router.navigateByUrl('/admin/departments');
        }
      })
    }
  }

  ngOnDestroy(): void {
    this.paramsSubscription?.unsubscribe();
    this.editDepartmentSubscription?.unsubscribe();
  }
}
