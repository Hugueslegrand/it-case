import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs";

@Injectable({
  providedIn: 'root'
})
export class SharedService {
  readonly APIUrl = "https://localhost:44345/api";

  constructor(private http: HttpClient) { }

  getTableList(): Observable < any[] > {
    return this.http.get < any > (this.APIUrl+'/Tables/GetTableNames/getTableNames');
}
/*addDatabase(val: any) {
  return this.http.post(this.APIUrl + '/Tables', val);
}*/
selectedTable(val:string):any{
  return this.http.post(this.APIUrl+'/Tables/SelectTable',val);
}

}
