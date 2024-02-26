import { Component } from '@angular/core';
import {FormBuilder, Validators, FormsModule, ReactiveFormsModule, FormControl} from '@angular/forms';
import {MatInputModule} from '@angular/material/input';
import {MatFormFieldModule} from '@angular/material/form-field';
import {MatStepperModule} from '@angular/material/stepper';
import {MatButtonModule} from '@angular/material/button';
import { User } from '../../classes/User';
import { UserServerService } from '../../../server/user-server.service';
import { NgIf } from '@angular/common';
import {MatCheckboxModule} from '@angular/material/checkbox';
import Swal from 'sweetalert2';
import { ErrorStateMatcher } from '@angular/material/core';


@Component({
  selector: 'app-register',
  standalone: true,
  imports: [MatButtonModule,
    MatStepperModule,
    FormsModule,
    ReactiveFormsModule,
    MatFormFieldModule,
    MatInputModule,
    NgIf,
    MatCheckboxModule
  ],
  templateUrl: './register.component.html',
  styleUrl: './register.component.css'
})
export class RegisterComponent {

  emailFormControl = new FormControl('', [Validators.required, Validators.email]);


  newUser:User=new User();
  serviceVariable:UserServerService  | undefined

  constructor(public server:UserServerService){
      this.serviceVariable=server;
      this.newUser=this.server.CurentUser
  }

  //שינוי משתנה עזרה ראשונה
  updateFirstAid() {
    this.newUser.userFirstAid = true;
  }

  //שליחת טופס
  send(){
    debugger
    //במידה ויש לי משתמש מחובר למערכת,
    //אני שולחת לפונקצית עדכון פרטי משתמש
    if(this.server.CurentUser.idUser){
      debugger
      this.server.update(this.server.CurentUser.idUser,this.newUser).subscribe(
        succ=>{
          // this.server.CurentUser=succ
          Swal.fire('Success!',"The details have been successfully updated" , 'success');
        },
        err=>{
          console.log(err), 
          alert("faild")
        },
        )
    }
    //במידה ואין כרגע משתמש מחובר
    //שליחה לפונקצית הוספת משתמש
    else{
      debugger
    this.server.addUser(this.newUser).subscribe(   
      a=>{
        this.server.CurentUser=a;
        console.log(a)
        Swal.fire('Success!',"hello "+this.newUser.userFirstName+'!!' , 'success');
        },
      b=>{console.log("שגיאה")}
    )
      }

  }
  matcher = new ErrorStateMatcher

}
