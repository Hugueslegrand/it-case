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
  chosenDatabase:any;

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

  AddDatabase(){
    this.chosenDatabase={
      databaseName:""
    }
    this.modalTitle = "choose Database";

  }

}
