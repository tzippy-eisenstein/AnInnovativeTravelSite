import { Component, OnInit } from '@angular/core';
import { UserServerService } from '../../../server/user-server.service';
import { TripServerService } from '../../../server/trip-server.service';
import { Trip } from '../../classes/Trip';
import { Booking } from '../../classes/Booking';
import { RouterModule, RouterOutlet } from '@angular/router';
import { CommonModule } from '@angular/common';
import { User } from '../../classes/User';
import { MatDialog, MatDialogModule } from '@angular/material/dialog';
import { BookingServerService } from '../../../server/booking-server.service';
import { allowedNodeEnvironmentFlags } from 'process';
import { MatTabGroup, MatTabsModule } from '@angular/material/tabs';
import { MatIconModule } from '@angular/material/icon';
import { NgModel } from '@angular/forms';
import {MatSliderModule} from '@angular/material/slider';
import {MatCheckboxModule} from '@angular/material/checkbox';
import {FormsModule} from '@angular/forms';
import {MatInputModule} from '@angular/material/input';
import {MatCardModule} from '@angular/material/card';
import { BooleanInput } from '@angular/cdk/coercion';
import {MatFormFieldModule} from '@angular/material/form-field';
import { log } from 'console';
import { TripsType } from '../../classes/TripsType';
import { HttpClientModule } from '@angular/common/http';
import { Router } from '@angular/router';
import { MatButtonModule } from '@angular/material/button';
import {MatChipsModule} from '@angular/material/chips';


@Component({
  selector: 'app-personal-area',
  standalone: true,
  imports: [
    RouterModule,
    CommonModule,
    RouterOutlet,
    MatIconModule,
    MatInputModule,
    MatTabsModule,
    MatDialogModule,
    FormsModule ,
    MatCardModule,
    MatFormFieldModule,
    MatInputModule,
    MatCheckboxModule,
    MatSliderModule,   
    HttpClientModule ,
    RouterOutlet,
    RouterModule, 
    MatButtonModule,
    MatChipsModule   ],
    
  templateUrl: './personal-area.component.html',
  styleUrls: ['./personal-area.component.css','../our-trips/./our-trips.component.css']
})

export class PersonalAreaComponent implements OnInit {

all() {
}

orders: any;
thumbLabel: BooleanInput;
showTicks: BooleanInput;
value: any;
disabled: BooleanInput;
selectedType: any;


  constructor(public userServer:UserServerService,
              public tripServer:TripServerService,
              public bookingServer:BookingServerService, 
              public dialog:MatDialog,
              public router:Router
             ){}
  

  booking:Array<Booking>=new Array<Booking> (); //רשימת כל ההזמנות
  trip:Trip=new Trip();
  curentBooking:Booking=new Booking(); //הזמנה נוכחית

  userTrip:Array<Trip>=new Array<Trip>();//כל טיולי המשתמש
  filteredUserTrip: Array<Trip> = []; 
  ListTypeTrips:Array<TripsType>=new Array<TripsType>();//כל סוגי הטיולים
  ListTripsFilter:Array<Trip>=new Array<Trip>()//סינון טיולים


  //סינון לפי מחירים
  max = 1000;
  min = 0;
  step = 1;
  val:any
  minPrice: any | undefined;
  maxPrice: any | undefined;
  

//סינון לפי תאריך
  byDate() {
    debugger
    let d=new Date()
this.filteredUserTrip=this.filteredUserTrip.filter(x=>x.dateTrip!.getFullYear<d.getFullYear)
     
    }

    //סינון לפי סוג טיול
   filter(id:number) {
      debugger
      this.filteredUserTrip=this.userTrip.filter(a=>a.idType==id)
    }

    //המרת תאריכים
  compareDates(date1: Date, date2: Date): number {
    debugger
    const date3 = new Date(date1);
    if (date3 < date2) {
      return -1;
    } else if (date3 > date2) {
      return 1;
    } else {
      return 0;
    }
  }

  ngOnInit(): void {

    //שליפת כל סוגי הטיולים
  this.tripServer.getTripType().subscribe(
    succ=>{this.ListTypeTrips=succ;},
    err=>{console.log(err)}
          )

    this.filteredUserTrip=this.userTrip 
    debugger;
    this.filteredUserTrip = [...this.userTrip];

    if (this.userServer.CurentUser.idUser) {
      debugger;
      // שליפת כל הטיולים למשתמש מסוים
      this.userServer.GetAllTrips(this.userServer.CurentUser.idUser).subscribe(
        succ => {
          this.booking = succ;
          console.log(succ);
  
          for (const trip of this.booking) {
            if(trip.idTrip){
            this.tripServer.getById(trip.idTrip).subscribe(
              b=> {
                this.userTrip.push(b)
              },
              err => {
                console.log("error");
                alert("failed");
              }
            );
          }
        }
        },
      );
    }
    this.filteredUserTrip=this.userTrip
  }


  //מחיקת משתמש
  deleteUser(){
    this.userServer.delete(this.userServer.CurentUser.idUser).subscribe(
      // this.userServer.GetAllTrips(this.userServer.CurentUser.idUser).subscribe(
        succ => {
         if(succ==true)
           alert("good");
         else
           alert("faild") 
        }, 
        err => {
          console.log("error");
          alert("failed");
        }
    )
  }

  //מחיקת הזמנה
  deleteBooking(id:number) {
    debugger
     this.curentBooking=this.booking.find(a =>a.idTrip==id)!
     this.bookingServer.delete(this.curentBooking.idBooking!).subscribe(
      succ => {
         if(succ==true)
          alert("good");
         else
          alert("faild")
       }, 
       err => {
         console.log("error");
         alert("failed");
       }
     )
  }

  //סינון לפי מחיר
  filterByPrice(value:number) {
    debugger
    this.filteredUserTrip = this.userTrip.filter( trip =>
       trip.price! >= this.min! && trip.price! <=value
    );
  }

  //עדכון פרטי משתמש-שליחה לטופס הרשמה
  update() {
    this.router.navigate(['register'])
  }
  //ניתןב לדף פרטי טיול
  openTripPanel(trip:Trip){
    this.router.navigate([`TripPanel/${trip.idTrip}`]);

  }

}
