import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { TableComponent } from './table/table.component';
import { ShowTaComponent } from './table/show-ta/show-ta.component';


import { HttpClientModule } from "@angular/common/http";
import { SharedService } from "./shared.service";
import { FormsModule,ReactiveFormsModule } from "@angular/forms";
import { ColumnComponent } from './column/column.component';
import { ShowColComponent } from './column/show-col/show-col.component';
import { DatabaseComponent } from './database/database.component';
import { ShowDatabaseComponent } from './database/show-database/show-database.component';
import { ValueComponent } from './value/value.component';


@NgModule({
  declarations: [
    AppComponent,
    TableComponent,
    ShowTaComponent,
    ColumnComponent,
    ShowColComponent,
    DatabaseComponent,
    ShowDatabaseComponent,
    ValueComponent,

  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule
  ],
  providers: [SharedService],
  bootstrap: [AppComponent]
})
export class AppModule { }
