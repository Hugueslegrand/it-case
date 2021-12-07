import { Component, OnInit } from '@angular/core';
import { SharedService } from '../shared.service';

@Component({
  selector: 'app-database',
  templateUrl: './database.component.html',
  styleUrls: ['./database.component.css']
})
export class DatabaseComponent implements OnInit {

  constructor(private sharedService: SharedService) { }

  ngOnInit(): void {
  }

  SelectDatabaseBE(){
    this.sharedService.selectDatabase("Be").subscribe(data => {
    })
  }
  SelectDatabaseNL(){
    this.sharedService.selectDatabase("Nl").subscribe(data => {
    })
  }
  SelectDatabasePL(){
    this.sharedService.selectDatabase("Pl").subscribe(data => {
    })
  }
  SelectDatabaseUK(){
    this.sharedService.selectDatabase("Uk").subscribe(data => {
    })
  }
  SelectDatabaseJP(){
    this.sharedService.selectDatabase("Jp").subscribe(data => {
    })
  }
  SelectDatabaseUS(){
    this.sharedService.selectDatabase("Us").subscribe(data => {
    })
  }

}
