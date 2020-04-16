import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { error } from 'util';

@Injectable()
export class Lab1Service{
    constructor(private http:HttpClient){}

    findResult1(list:string){
        const body={
            Data1:list,
            Data2:"" 
        }
        let headers=new HttpHeaders({
            "Content-Type": "text/json"
        });
        let options={headers:headers};
        return this.http.post(environment.lab1.findResult1, body, options);
    }

    getResult1(key:string):Observable<string>{
        let url = environment.lab1.getResult1+"/"+key;
        return this.http.get<string>(url);
    }

    findResult2(list:string){
        const body={
            Data1:"",
            Data2:list 
        }
        let headers=new HttpHeaders({
            "Content-Type": "text/json"
        });
        let options={headers:headers};
        return this.http.post(environment.lab1.findResult2, body, options);
    }

    getResult2(key:string):Observable<string>{
        let url = environment.lab1.getResult2+"/"+key;
        return this.http.get<string>(url);
    }
}