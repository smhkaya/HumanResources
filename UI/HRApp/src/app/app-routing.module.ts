import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DepartmentListComponent } from './features/department/department-list/department-list.component';
import { AddDepartmentComponent } from './features/department/add-department/add-department.component';
import { EditDepartmentComponent } from './features/department/edit-department/edit-department.component';
import { EmployeeListComponent } from './features/employee/employee-list/employee-list.component';
import { AddEmployeeComponent } from './features/employee/add-employee/add-employee.component';
import { EditEmployeeComponent } from './features/employee/edit-employee/edit-employee.component';

const routes: Routes = [
  {
    path: 'admin/departments',
    component: DepartmentListComponent
  },
  {
    path: 'admin/departments/add',
    component: AddDepartmentComponent
  },
  {
    path: 'admin/departments/:id',
    component: EditDepartmentComponent
  },
  {
    path: 'admin/employees',
    component: EmployeeListComponent
  },
  {
    path: 'admin/employees/add',
    component: AddEmployeeComponent
  },
  { path: 'admin/employees/edit/:id', 
    component: EditEmployeeComponent 
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
