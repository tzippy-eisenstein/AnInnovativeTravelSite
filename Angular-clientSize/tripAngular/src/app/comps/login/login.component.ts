import {Component, OnInit} from '@angular/core';
import {MatInputModule} from '@angular/material/input';
import {MatFormFieldModule} from '@angular/material/form-field';
import {FormControl, FormGroupDirective, FormsModule, NgForm, ReactiveFormsModule, Validators,} from '@angular/forms';
import { Router, RouterModule, RouterOutlet } from '@angular/router';
import { routes } from '../../app.routes';
import { UserServerService } from '../../../server/user-server.service';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { User } from '../../classes/User';
import {MatButtonModule} from '@angular/material/button';
import Swal from 'sweetalert2';
import { ErrorStateMatcher } from '@angular/material/core';
import { NgIf } from '@angular/common';

//validators
export class MyErrorStateMatcher implements ErrorStateMatcher {
  isErrorState(control: FormControl | null, form: FormGroupDirective | NgForm | null): boolean {
    const isSubmitted = form && form.submitted;
    return !!(control && control.invalid && (control.dirty || control.touched || isSubmitted));
  }
}


@Component({
  selector: 'app-login',
  standalone: true,
  imports: [FormsModule, MatFormFieldModule,MatInputModule,
            RouterModule,HttpClientModule,MatButtonModule,RouterOutlet,
            ReactiveFormsModule,NgIf],
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'

})
export class LoginComponent implements OnInit{

  emailFormControl = new FormControl('', [Validators.required, Validators.email]);
  
  constructor( public server:UserServerService,public router:Router){ }
    
 
  //שליחת טופס התחברות
submitForm(email: string, password: string): void {
  this.server.getByEmailAndPassword(email, password).subscribe(
    succ => {
      debugger
      const localMan = localStorage.getItem('Manager')
      const myManager = JSON.parse(localMan!);
     
      //משתמש לא נמצא
      if(succ==null){
        Swal.fire('Oops!', 'user not defined ', 'error');
        this.router.navigate(['register'])
      }

      //בדיקה אם נכנס מנהל
      if(succ.userEmail ==myManager.userEmail  && succ.userPassword==myManager.userPassword){
        this.server.maneger=succ;
        Swal.fire('Success!',"hello maneger" , 'success');
        this.router.navigate(['ManegerComponent'])
     }
      //כניסת משתמש
      else if(succ!=null)  {
        this.server.CurentUser=succ;
        // alert(succ.userFirstName + " hello");
        Swal.fire('Success!',"hello " +succ.userFirstName, 'success');
        this.router.navigate(['ourTrips']);

      }
  
    },
    error => {
      debugger
      Swal.fire('Oops!', 'user not defined ', 'error');
    }
  );
}

ngOnInit() {

}
matcher = new ErrorStateMatcher
};
