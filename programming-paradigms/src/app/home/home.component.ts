import { Component, OnInit } from '@angular/core';
import { labs } from '../shared/models/helper/labs';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  labs:labs[];

  constructor() { }

  ngOnInit() {
    this.labs = [
      {name:"Lab 1", link:"lab1"},
      {name:"Lab 2", link:"lab2"},
      {name:"Lab 3", link:"lab3"},
      {name:"Lab 4", link:"lab4"}
    ]
  }

}
