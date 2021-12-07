import { Component, OnInit } from '@angular/core';
import { SharedService } from '../shared.service';

@Component({
  selector: 'app-database',
  templateUrl: './database.component.html',
  styleUrls: ['./database.component.css']
})
export class DatabaseComponent implements OnInit {
  database:string= "test";

  constructor(private sharedService: SharedService) { }

  ngOnInit(): void {
  }

selectedDatabase(item: any){
  item = this.selectedDatabase;
  //Send the value to the post request
  this.sharedService.selectedDatabase(item);
  console.log(item);
}
}
