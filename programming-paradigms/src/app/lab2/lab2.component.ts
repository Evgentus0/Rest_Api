import { Component, OnInit } from '@angular/core';
import { lab2 } from '../shared/models/lab2';
import { Lab2Service } from '../shared/services/lab2.service';

@Component({
  selector: 'app-lab2',
  templateUrl: './lab2.component.html',
  styleUrls: ['./lab2.component.css']
})
export class Lab2Component implements OnInit {
  data:lab2 = new lab2();
  result:string;
  title:string;

  constructor(private service:Lab2Service) { }

  ngOnInit() {
    this.title="Lab 2";
    this.result="N/A";
  }

  find(){
    this.service.findResult(this.data.data).subscribe((key:string)=>{
      this.service.getResult(key).subscribe((data:string)=>{
        this.result = data;
      },
      error=>console.log(error))
    },
    error=>{
      console.log(error);
      this.result = error["error"];
    })
  }
}
