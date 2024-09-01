import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { Employee } from '../models/employee.model';
import { AddEmployee } from '../models/add-employee.model';
import { environment } from 'src/environments/environment';
import { UpdateEmployeeRequest } from '../models/update-employee-request.model';

@Injectable({
  providedIn: 'root'
})
export class EmployeeService {

  constructor(private http: HttpClient) { }

  createEmployee(model: AddEmployee): Observable<void> {
    return this.http.post<void>(`${environment.apiBaseUrl}/api/employee`, model);
  }

  getAllEmployees(): Observable<Employee[]> {
    return this.http.get<Employee[]>(`${environment.apiBaseUrl}/api/employee`);
  }

  getEmployeeById(id: string): Observable<Employee> {
    return this.http.get<Employee>(`${environment.apiBaseUrl}/api/employee/${id}`);
  }

  updateEmployee(id: string, updateEmployeeRequest: UpdateEmployeeRequest): Observable<Employee> {
    return this.http.put<Employee>(`${environment.apiBaseUrl}/api/employee/${id}`, updateEmployeeRequest);
  }

  deleteEmployee(id: string): Observable<Employee> {
    return this.http.delete<Employee>(`${environment.apiBaseUrl}/api/employee/${id}`);
  }
}
