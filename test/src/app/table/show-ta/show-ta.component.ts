import { Component, OnInit } from '@angular/core';
import { SharedService } from "src/app/shared.service";

@Component({
  selector: 'app-show-ta',
  templateUrl: './show-ta.component.html',
  styleUrls: ['./show-ta.component.css']
})
export class ShowTaComponent implements OnInit {
  tableList:any = [];

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
    //Send the value to the post request
    this.sharedService.selectedTable(item.tableNames).subscribe(data => {
    });
    console.log(item.tableNames);
  }
  
}

