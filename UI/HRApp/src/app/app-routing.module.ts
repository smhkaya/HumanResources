import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DepartmentListComponent } from './features/department/department-list/department-list.component';
import { AddDepartmentComponent } from './features/department/add-department/add-department.component';

const routes: Routes = [
  {
    path: 'admin/departments',
    component: DepartmentListComponent
  },
  {
    path: 'admin/departments/add',
    component: AddDepartmentComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
