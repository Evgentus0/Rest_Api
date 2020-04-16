import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';


@Injectable()
export class Lab2Service{
    constructor(private http:HttpClient){}

    findResult(list:string){
        const body = {
            Data:list
        }
        let headers=new HttpHeaders({
            "Content-Type": "text/json"
        });

        let options={headers:headers};
        return this.http.post(environment.lab2.findResult, body, options);
    }

    getResult(key:string):Observable<string>{
        let url = environment.lab2.getResult+"/"+key;
        return this.http.get<string>(url);
    }
}