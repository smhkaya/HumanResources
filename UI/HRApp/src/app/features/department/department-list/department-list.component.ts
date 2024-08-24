import { Component, OnInit } from '@angular/core';
import { DepartmentService } from '../services/department.service';
import { Department } from '../models/department.model';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-department-list',
  templateUrl: './department-list.component.html',
  styleUrls: ['./department-list.component.css']
})
export class DepartmentListComponent implements OnInit {
departments$?: Observable<Department[]>;


  constructor(private departmentService: DepartmentService){

  }

  ngOnInit(): void {
    this.departments$ = this.departmentService.getAllDepartments();

  }
}
