import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { Lab1Component } from './lab1/lab1.component';
import { AboutMeComponent } from './about-me/about-me.component';
import { Lab2Component } from './lab2/lab2.component';
import { Lab3Component } from './lab3/lab3.component';
import { Lab4Component } from './lab4/lab4.component';


const routes: Routes = [
  {path:"home", component:HomeComponent},
  {path:"about-me", component:AboutMeComponent},
  {path:"home/lab1", component:Lab1Component},
  {path:"home/lab2", component:Lab2Component},
  {path:"home/lab3", component:Lab3Component},
  {path:"home/lab4", component:Lab4Component},
  {path:"", pathMatch:"full", redirectTo:"home"}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
