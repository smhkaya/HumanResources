import { Injectable } from '@angular/core';
import { AddDepartmentRequest } from '../department/models/add-department-request.model';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class DepartmentService {

  constructor(private http: HttpClient) { }

  addDepartment(model:AddDepartmentRequest): Observable<void>{
    return this.http.post<void>('http://localhost:5127/api/department', model);
  }
}
