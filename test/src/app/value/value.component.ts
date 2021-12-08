import { Component, OnInit } from '@angular/core';
import { SharedService } from '../shared.service';

@Component({
  selector: 'app-value',
  templateUrl: './value.component.html',
  styleUrls: ['./value.component.css']
})
export class ValueComponent implements OnInit {
  valueList:any = [];

  constructor(private sharedService: SharedService) { }

  ngOnInit(): void {
    this.refreshValueList();
  
  }
  refreshValueList() {
    this.sharedService.getValueList().subscribe(data =>{
      this.valueList = data;
      console.log(this.valueList);
    });
  }
//Function to save selected table from the onclick
  selectedValue(item: any){
    //Send the value to the post request
    this.sharedService.selectedValue(item.valueNames).subscribe(data => {
    });
    console.log(item.valueNames);
  }
}