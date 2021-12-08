import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ColumnComponent } from './column/column.component';
import { DatabaseComponent } from './database/database.component';
import { TableComponent } from './table/table.component';
import { ValueComponent } from './value/value.component';

const routes: Routes = [
  {path:'table', component: TableComponent},
  {path:'column',component: ColumnComponent},
  {path:'database',component:DatabaseComponent},
  {path:'value',component:ValueComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
