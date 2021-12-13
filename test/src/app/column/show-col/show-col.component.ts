import { Component, OnInit } from '@angular/core';
import { SharedService } from 'src/app/shared.service';

interface AddColumn{
  columnNames:string
}
@Component({
  selector: 'app-show-col',
  templateUrl: './show-col.component.html',
  styleUrls: ['./show-col.component.css']
})
export class ShowColComponent implements OnInit {
  columnList:any = [];
  modalTitle:any;
  activateAddEditColCom:boolean = false;
  column:any;
  addColumnString = "";

  constructor(private sharedService: SharedService) { }

  ngOnInit(): void {
    this.refreshColumnList();
  
  }
  refreshColumnList() {
    this.sharedService.getColumnList().subscribe(data =>{
      this.columnList = data;
      console.log(this.columnList);
    });
  }
//Function to save selected column from the onclick
  selectedColumn(item: any){
    this.column= item;
    this.modalTitle = "Select Column";
    this.activateAddEditColCom = true;
    //Send the value to the post request
    this.sharedService.selectedColumn(item);
    // console.log(item.columnNames);
  }

  //Function to add a column
  onChange(input: any){
    this.addColumnString = input.target.value;
  }

  addColumn(){
    let newColumn: AddColumn = {columnNames: this.addColumnString} ;
    this.columnList.push(newColumn);
  }

  
}
