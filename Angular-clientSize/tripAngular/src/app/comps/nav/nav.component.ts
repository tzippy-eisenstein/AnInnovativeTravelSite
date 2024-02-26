import { Component } from '@angular/core';
import { UserServerService } from '../../../server/user-server.service';
import { CommonModule } from '@angular/common';
import { RouterModule, RouterOutlet } from '@angular/router';
import {MatTooltip} from '@angular/material/tooltip';
import { FormControl, NgModel } from '@angular/forms';
import {MatTooltipModule} from '@angular/material/tooltip';


@Component({
  selector: 'app-nav',
  standalone: true,
  imports: [
    CommonModule,
    RouterOutlet, 
    RouterModule,
    MatTooltipModule,
  ],
  templateUrl: './nav.component.html',
  styleUrl: './nav.component.css'
})
export class NavComponent {
  disabled = new FormControl(false);

  serviceVariable:UserServerService  | undefined

  currentUser: any;

  constructor(server:UserServerService){
    debugger
    this.serviceVariable=server;
  }
}
