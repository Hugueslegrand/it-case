import { Component, OnInit } from '@angular/core';
import { SharedService } from 'src/app/shared.service';

@Component({
  selector: 'app-show-col',
  templateUrl: './show-col.component.html',
  styleUrls: ['./show-col.component.css']
})
export class ShowColComponent implements OnInit {
  columnList:any = [];


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
    //Send the value to the post request
    this.sharedService.selectedColumn(item).subscribe(data => {
    });
  }
  
}