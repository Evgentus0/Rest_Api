import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Automat } from '../models/helper/automat';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class Lab3Service {

  constructor(private http: HttpClient) { }

  findResult(automat:Automat, length:number){
    const body = {
      Automat:automat,
      Length:length
    }

    let headers=new HttpHeaders({
      "Content-Type": "text/json"
    });
    let options={headers:headers};
    return this.http.post(environment.lab3.findResult, body, options);
  }

  getResult(key:string):Observable<string>{
    let url = environment.lab3.getResult+"/"+key;
    return this.http.get<string>(url);
}
  
}
