import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NavbarComponent } from './core/components/navbar/navbar.component';
import { DepartmentListComponent } from './features/department/department-list/department-list.component';
import { AddDepartmentComponent } from './features/department/add-department/add-department.component';
import { FormsModule } from '@angular/forms';
import {HttpClientModule} from '@angular/common/http';
import { EditDepartmentComponent } from './features/department/edit-department/edit-department.component'

@NgModule({
  declarations: [
    AppComponent,
    NavbarComponent,
    DepartmentListComponent,
    AddDepartmentComponent,
    EditDepartmentComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
