import { Component, OnDestroy } from '@angular/core';
import { AddDepartmentRequest } from '../models/add-department-request.model';
import { Subscription } from 'rxjs';
import { DepartmentService } from '../services/department.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-add-department',
  templateUrl: './add-department.component.html',
  styleUrls: ['./add-department.component.css']
})
export class AddDepartmentComponent implements OnDestroy {

  model: AddDepartmentRequest;
  private addDepartmentSubscribtion? : Subscription;




  constructor(private departmentService : DepartmentService,
    private router: Router)
    {
    this.model = {
      name: '',
      location: ''
    };
  }


  onFormSubmit(){
    this.addDepartmentSubscribtion = this.departmentService.addDepartment(this.model)
    .subscribe({
      next: (response) => {
        this.router.navigateByUrl('/admin/departments');

      }
    });
  }

  ngOnDestroy(): void {
    this.addDepartmentSubscribtion?.unsubscribe();
  }

}
