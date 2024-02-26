import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { RouterModule, RouterOutlet } from '@angular/router';
import { UserServerService } from '../../../server/user-server.service';
import { User } from '../../classes/User';

@Component({
  selector: 'app-maneger',
  standalone: true,
  imports: [
    CommonModule,
    RouterModule,
    RouterOutlet
   
  ],
  templateUrl: './maneger.component.html',
  styleUrl: './maneger.component.css'
})
export class ManegerComponent implements OnInit{
  constructor(public server:UserServerService){}
  ListUser:Array<User>=new Array<User>();

  ngOnInit(): void {
    debugger
    //קבלת כל המשתמשים 
    this.server.getAll().subscribe(
      succ => {
        this.ListUser=succ;
      },
        err=>{
            console.log("error");
            alert("failed");}
    )
        }}



