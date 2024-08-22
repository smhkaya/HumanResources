import { Component } from '@angular/core';
import { AddDepartmentRequest } from '../models/add-department-request.model';
import { DepartmentService } from '../../services/department.service';

@Component({
  selector: 'app-add-department',
  templateUrl: './add-department.component.html',
  styleUrls: ['./add-department.component.css']
})
export class AddDepartmentComponent {

  model: AddDepartmentRequest;

  constructor(private departmentService : DepartmentService){
    this.model = {
      name: '',
      location: ''
    };
  }


  onFormSubmit(){
    this.departmentService.addDepartment(this.model)
    .subscribe({
      next: (response) => {
        console.log('Succesful!');
      }
    });
  }
}
