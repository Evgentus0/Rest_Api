import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';
import { Lab1Component } from './lab1/lab1.component';
import { Lab1Service } from './shared/services/lab1.service';
import { AboutMeComponent } from './about-me/about-me.component';
import { Lab2Component } from './lab2/lab2.component';
import { Lab2Service } from './shared/services/lab2.service';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    Lab1Component,
    AboutMeComponent,
    Lab2Component
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule
  ],
  providers: [
    Lab1Service,
    Lab2Service
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
