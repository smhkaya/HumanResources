import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DepartmentListComponent } from './features/department/department-list/department-list.component';
import { AddDepartmentComponent } from './features/department/add-department/add-department.component';
import { EditDepartmentComponent } from './features/department/edit-department/edit-department.component';
import { EmployeeListComponent } from './features/employee/employee-list/employee-list.component';
import { AddEmployeeComponent } from './features/employee/add-employee/add-employee.component';
import { EditEmployeeComponent } from './features/employee/edit-employee/edit-employee.component';
import { LoginComponent } from './features/auth/login/login.component';
import { authGuard } from './features/auth/guards/auth.guard';

const routes: Routes = [

  {
    path: 'login',
    component: LoginComponent
  },
  {
    path: 'admin/departments',
    component: DepartmentListComponent,
    canActivate: [authGuard]
  },
  {
    path: 'admin/departments/add',
    component: AddDepartmentComponent,
    canActivate: [authGuard]
  },
  {
    path: 'admin/departments/:id',
    component: EditDepartmentComponent,
    canActivate: [authGuard]
  },
  {
    path: 'admin/employees',
    component: EmployeeListComponent,
    canActivate: [authGuard]
  },
  {
    path: 'admin/employees/add',
    component: AddEmployeeComponent,
    canActivate: [authGuard]
  },
  { path: 'admin/employees/edit/:id', 
    component: EditEmployeeComponent,
    canActivate: [authGuard]
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
