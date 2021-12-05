import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ColumnComponent } from './column/column.component';
import { TableComponent } from './table/table.component';

const routes: Routes = [
  {path:'table', component: TableComponent},
  {path:'column',component: ColumnComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
