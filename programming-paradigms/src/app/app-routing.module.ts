import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { Lab1Component } from './lab1/lab1.component';
import { AboutMeComponent } from './about-me/about-me.component';


const routes: Routes = [
  {path:"home", component:HomeComponent},
  {path:"lab1", component:Lab1Component},
  {path:"about-me", component:AboutMeComponent},
  {path:"home/lab1", redirectTo:"lab1"},
  {path:"", pathMatch:"full", redirectTo:"home"}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
