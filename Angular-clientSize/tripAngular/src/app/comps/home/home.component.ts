import { Component, OnInit, computed } from '@angular/core';
import{CommonModule} from '@angular/common'
import { UserServerService } from '../../../server/user-server.service';
import { User } from '../../classes/User';
import { Server } from 'http';
import { Route, Router, RouterModule, RouterOutlet } from '@angular/router';
import {MatButtonModule} from '@angular/material/button';

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [CommonModule,RouterModule,RouterOutlet,MatButtonModule],
  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
})
export class HomeComponent implements OnInit {
  serviceVariable:UserServerService | undefined ;
  manager:User | undefined 

 constructor(server:UserServerService,public router:Router ){
   this.serviceVariable=server;
   this.manager=this.serviceVariable.maneger }
    

  ngOnInit(): void {
   debugger
   //הכנסת פרטי מנהל ללוקל סטורז
   const manager = JSON.stringify({ userEmail: "0898@gmail.com", userPassword: "1111" })
   localStorage.setItem('Manager', manager)

}

click(){
  this.router.navigate(['login']);
}
}
