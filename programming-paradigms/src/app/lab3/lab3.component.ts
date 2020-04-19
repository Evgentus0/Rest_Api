import { Component, OnInit } from '@angular/core';
import { Automat } from '../shared/models/helper/automat';
import { FormGroup, FormControl, Validators, FormArray } from '@angular/forms';
import { ArrayType } from '@angular/compiler';
import { parse } from 'querystring';
import { Lab3Service } from '../shared/services/lab3.service';

@Component({
  selector: 'app-lab3',
  templateUrl: './lab3.component.html',
  styleUrls: ['./lab3.component.css']
})
export class Lab3Component implements OnInit {
  title:string;
  result:string;
  automat:Automat = new Automat();

  myForm : FormGroup;
  constructor(private service:Lab3Service) { }

  ngOnInit() {
    this.title="Lab 3";
    this.result = "N/A";

    this.myForm = new FormGroup({
      "Length": new FormControl("", [Validators.required]),
      "States": new FormControl("", [Validators.required]),
      "StartState": new FormControl("", [Validators.required]),
      "FinalStates": new FormControl("", [Validators.required]),
      "Transitions": new FormArray([
          new FormControl("", Validators.required)
      ])
    });
  }

  addTransition(){
    (<FormArray>this.myForm.controls["Transitions"]).push(new FormControl("", Validators.required));
  }

  deleteTransition(){
    let length = (<FormArray>this.myForm.controls["Transitions"]).length;
    if(length>1){
      (<FormArray>this.myForm.controls["Transitions"]).removeAt(length-1);
    }
    else{
      alert("Must be at least one transition!");
    }
  }

  findResult(){
    let automat = this.getAutomat();
    let lengthString:string = this.myForm.value["Length"]; 
    let length = parseInt(lengthString);

    this.service.findResult(automat, length).subscribe((key:string)=>{
      this.service.getResult(key).subscribe((data:string)=>{
        this.result = data;
      })
    })
  }

  private getAutomat():Automat{
    let automat:Automat = new Automat();

    let statesString:string= this.myForm.value["States"];
    let statesArr =  statesString.split(",");
    statesArr.forEach(elem=>{
      automat.States.push(parseInt(elem));
    });

    let finalStatesString:string= this.myForm.value["FinalStates"];
    let finalStatesArr =  finalStatesString.split(",");
    finalStatesArr.forEach(elem=>{
      automat.FinalStates.push(parseInt(elem));
    });

    let startStateString:string = this.myForm.value["StartState"];
    automat.StartState = parseInt(startStateString);

    let transitionStrings:string[] = this.myForm.value["Transitions"];

    transitionStrings.forEach(elem=>{
      let transition = elem.split(",");
      if(transition.length!=3){
        throw "Incorrect transition";
      }
      automat.Transitions.push({
        PrevState:parseInt(transition[0]),
        Symbol:transition[1],
        NextState:parseInt(transition[2])
      });
    });

    return automat;
  }
}
