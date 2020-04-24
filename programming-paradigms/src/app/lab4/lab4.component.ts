import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, FormArray, Validators } from '@angular/forms';
import { Grammar } from '../shared/models/helper/grammar';
import { Lab4Service } from '../shared/services/lab4.service';
import { Lab4 } from '../shared/models/lab4';

@Component({
  selector: 'app-lab4',
  templateUrl: './lab4.component.html',
  styleUrls: ['./lab4.component.css']
})
export class Lab4Component implements OnInit {
  title:string;
  showingDetails:boolean;

  result:string;
  resultWithDetails:Lab4;

  myForm : FormGroup;
  constructor(private service:Lab4Service) { }

  ngOnInit() {
    this.showingDetails = false;
    this.title = "Lab 4";
    this.result="N/A";
    this.resultWithDetails = {
      isLL1:true,
      details:[
        {
          firsts:["sd", "sad"],
          follow:"Sdsd",
          nonTerminal:"S"
        },
        {
          firsts:["sd", "sad"],
          follow:"Sdsd",
          nonTerminal:"S"
        }
      ]
    }

    this.myForm = new FormGroup({
      "NonTerminals": new FormControl("", [Validators.required]),
      "Terminals": new FormControl("", [Validators.required]),
      "Rules": new FormArray([
          new FormControl("", Validators.required)
      ])
    });
  }

  addRule(){
    (<FormArray>this.myForm.controls["Rules"]).push(new FormControl("", Validators.required));
  }
  deleteRule(){
    let length = (<FormArray>this.myForm.controls["Rules"]).length;
    if(length>1){
      (<FormArray>this.myForm.controls["Rules"]).removeAt(length-1);
    }
    else{
      alert("Must be at least one Rule!");
    }
  }

  findResult(){
    let grammar = this.getGrammar();
    this.showingDetails = false;
    this.service.findResult(grammar).subscribe((key:string)=>{
      this.service.getResult(key).subscribe((data:string)=>{
        this.result = data;
      },
      error=>console.error(error))
    },
    error=>{
      console.log(error);
      this.result = error["error"];
    })
  }

  findResultWithDetails(){
    let grammar = this.getGrammar();
    this.showingDetails = true;

    this.service.findResultWithDetails(grammar).subscribe((key:string)=>{
      this.service.getResultWithDetails(key).subscribe((data)=>{
        this.resultWithDetails = data;
        this.result = data.isLL1.toString();
      },
      error=>console.error(error))
    },
    error=>{
      console.log(error);
      this.result = error["error"];
    })
  }

  getGrammar():Grammar{
    let grammar = new Grammar();

    let nonTerminalsString:string= this.myForm.value["NonTerminals"];
    let nonTerminalsArr =  nonTerminalsString.split(",");
    grammar.NonTerminals = nonTerminalsArr;

    let terminalsString:string= this.myForm.value["Terminals"];
    let terminalsArr =  terminalsString.split(",");
    grammar.Terminals = terminalsArr;

    let rulesString:string[] = this.myForm.value["Rules"];

    rulesString.forEach(elem=>{
      let rule = elem.split("->");

      if(rule.length!=2){
        throw "Incorrect rule!";
      }

      grammar.Rules.push({
        LeftPart:rule[0],
        RightPart:rule[1]
      });
    })

    return grammar;
  }

}
