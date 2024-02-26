import { Component, OnInit } from '@angular/core';
import { CommonModule, NgFor } from '@angular/common';
import { RouterModule, RouterOutlet } from '@angular/router';
import { HomeComponent } from './comps/home/home.component';
import { RegisterComponent } from './comps/register/register.component';
import { LoginComponent } from './comps/login/login.component';
import { OurTripsComponent } from './comps/our-trips/our-trips.component';
import { HttpClientModule } from '@angular/common/http';
import { UserServerService } from '../server/user-server.service';
import { NavComponent } from './comps/nav/nav.component';
// import { BrowserModule } from '@angular/platform-browser';
import { TripPanelComponent } from './comps/trip-panel/trip-panel.component';
import { Server } from 'http';
import { User } from './classes/User';
import { PersonalAreaComponent } from './comps/personal-area/personal-area.component';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [
     CommonModule,
     RouterOutlet, 
     LoginComponent,
     RegisterComponent,
     OurTripsComponent,
     NavComponent,
     HomeComponent,
     HttpClientModule,
     RouterModule,
     PersonalAreaComponent,
  
     
    //  CommonModule,
    //  BrowserModule
         
    ],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent implements OnInit {
  title = 'tripAngular';
  serviceVariable:UserServerService | undefined ;
  
  constructor(server:UserServerService){
    this.serviceVariable=server;
    
  }
  ngOnInit(): void {
    debugger
   
  }
}