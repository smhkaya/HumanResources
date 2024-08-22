import { Component } from '@angular/core';
import { AddDepartmentRequest } from '../models/add-department-request.model';

@Component({
  selector: 'app-add-department',
  templateUrl: './add-department.component.html',
  styleUrls: ['./add-department.component.css']
})
export class AddDepartmentComponent {

  model: AddDepartmentRequest;

  constructor(){
    this.model = {
      name: 'Semih',
      location: ''
    };
  }


  onFormSubmit(){
    console.log(this.model);
  }
}
