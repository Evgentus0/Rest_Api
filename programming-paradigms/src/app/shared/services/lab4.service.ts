import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Grammar } from '../models/helper/grammar';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';
import { Lab4 } from '../models/lab4';


@Injectable({
    providedIn: 'root'
})
export class Lab4Service{

    constructor(private http: HttpClient) { }

    findResult(grammar:Grammar){
        const body={
            NonTerminals:grammar.NonTerminals,
            Terminals:grammar.Terminals,
            Rules:grammar.Rules
        }

        let headers=new HttpHeaders({
            "Content-Type": "text/json"
          });
        let options={headers:headers};

        return this.http.post(environment.lab4.findResult, body, options);
    }
    getResult(key:string):Observable<string>{
        let url = environment.lab4.getResult+"/"+key;
        return this.http.get<string>(url);
    }

    findResultWithDetails(grammar:Grammar){
        const body={
            NonTerminals:grammar.NonTerminals,
            Terminals:grammar.Terminals,
            Rules:grammar.Rules
        }

        let headers=new HttpHeaders({
            "Content-Type": "text/json"
          });
        let options={headers:headers};

        return this.http.post(environment.lab4.findResultWithDetails, body, options);
    }
    getResultWithDetails(key:string):Observable<Lab4>{
        let url = environment.lab4.getResultWithDetails+"/"+key;
        return this.http.get<Lab4>(url);
    }
}