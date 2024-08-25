import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { Department } from '../models/department.model';
import { AddDepartmentRequest } from '../models/add-department-request.model';
import { environment } from 'src/environments/environment';
import { UpdateDepartmentRequest } from '../models/update-department-request.model';

@Injectable({
  providedIn: 'root'
})
export class DepartmentService {

  constructor(private http: HttpClient) { }

  addDepartment(model: AddDepartmentRequest): Observable<void> {
    return this.http.post<void>(`${environment.apiBaseUrl}/api/department`, model);
  }

  getAllDepartments(): Observable<Department[]> {
    return this.http.get<Department[]>(`${environment.apiBaseUrl}/api/department`);
  }

  getDepartmentById(id:string): Observable<Department>{
    return this.http.get<Department>(`${environment.apiBaseUrl}/api/department/${id}`);
  }

  updateDepartment(id: string, updateDepartmentRequest: UpdateDepartmentRequest) : Observable<Department>
  {
    return this.http.put<Department>(`${environment.apiBaseUrl}/api/department/${id}`,
      updateDepartmentRequest);
  }

  deleteDepartment(id: string) : Observable<Department> {
    return this.http.delete<Department>(`${environment.apiBaseUrl}/api/department/${id}`)
  }
}
