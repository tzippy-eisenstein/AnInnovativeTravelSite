import { Component, Input, NO_ERRORS_SCHEMA, OnInit } from '@angular/core';
import { UserServerService } from '../../../server/user-server.service';
import { TripServerService } from '../../../server/trip-server.service';
import { Trip } from '../../classes/Trip';
import { NavigationExtras, Router, RouterModule } from '@angular/router';
import { DatePipe, NgFor, NgForOf, NgIf } from '@angular/common';
import { TripsType } from '../../classes/TripsType';
import { TripPanelComponent } from '../trip-panel/trip-panel.component';
import { FormsModule } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatSelectModule } from '@angular/material/select';
import { MatDividerModule } from '@angular/material/divider';
import {MatCardModule} from '@angular/material/card';
import {MatChipsModule} from '@angular/material/chips';
import { HttpClientModule } from '@angular/common/http';


@Component({
  selector: 'app-our-trips',
  standalone: true,
  imports: [
    RouterModule,
    NgFor,
    NgIf,
    NgForOf,
    FormsModule,
    MatSelectModule,
    MatButtonModule,
    MatDividerModule,
    MatCardModule,
     MatButtonModule,
     MatChipsModule,
     HttpClientModule
  ],
  templateUrl: './our-trips.component.html',
  styleUrl: './our-trips.component.css'
})
export class OurTripsComponent implements OnInit {

  date:Date | undefined
  selectedType: any;
  constructor(public server:TripServerService,public router:Router){
  }

  //סינון עפי סוג הטיול
filter(id:number)
{
  this.listTripFilter=this.listTrip.filter(a=>a.idType==id)
}

 //קבלת כל הטיולים
all(){
  this.listTripFilter=this.listTrip
}

  ngOnInit(): void {
    //שליפת כל הטיולים מהשרת
    debugger
    this.server.getAll().subscribe(
    succ=>{this.listTrip=succ;this.listTripFilter=this.listTrip;console.log(this.server);},
    err=>{console.log(err)}
    )

    this.server.getTripType().subscribe(
      succ=>{this.listTripTypes=succ;
      console.log(this.listTripTypes)},
      err=>{console.log(err)}
    )
  }
  
  
  listTrip:Array<Trip>=new Array<Trip>()  //רשימת כל הטיולים
  listTripTypes:Array<TripsType>=new Array<TripsType>() //רשימת כל סוגי הטילים
  listTripFilter:Array<Trip>=new Array<Trip>() //רשימת הטיולים לאחר סינון

  //ניתוב לקומפוננטת פרטים על הטיול
  openTripPanel(trip: Trip) {
    this.router.navigate([`TripPanel/${trip.idTrip}`]);
  }
}

