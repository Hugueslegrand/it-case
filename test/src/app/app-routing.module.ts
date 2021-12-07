import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DatabaseComponent } from './database/database.component';
import { TableComponent } from './table/table.component';

const routes: Routes = [
  {path:'table', component: TableComponent},
  {path:'database',component:DatabaseComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
