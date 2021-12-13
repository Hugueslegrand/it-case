import { Component, OnInit } from '@angular/core';
import { SharedService } from "src/app/shared.service";

@Component({
  selector: 'app-show-ta',
  templateUrl: './show-ta.component.html',
  styleUrls: ['./show-ta.component.css']
})
export class ShowTaComponent implements OnInit {
  tableList:any = [];
  modalTitle:any;
  activateAddEditTaCom:boolean = false;
  table:any;

  constructor(private sharedService: SharedService) { }

  ngOnInit(): void {
    this.refreshTableList();
  
  }
  refreshTableList() {
    this.sharedService.getTableList().subscribe(data =>{
      this.tableList = data;
      console.log(this.tableList);
    });
  }
//Function to save selected table from the onclick
  selectedTable(item: any){
    this.table= item;
    this.modalTitle = "Select Table";
    this.activateAddEditTaCom = true;
    //Send the value to the post request
    this.sharedService.selectedTable(item);
    console.log(item.tableNames);
  }
  
}

