import { NgFor, NgIf } from '@angular/common';
import { Component, Input, OnInit, Pipe } from '@angular/core';
import { TripServerService } from '../../../server/trip-server.service';

import { ActivatedRoute } from '@angular/router';
import { Trip } from '../../classes/Trip';
import { OurTripsComponent } from '../our-trips/our-trips.component';

import { Inject} from '@angular/core';
import {
  MatDialog,
  MAT_DIALOG_DATA,
  MatDialogRef,
  MatDialogTitle,
  MatDialogContent,
  MatDialogActions,
  MatDialogClose,
} from '@angular/material/dialog';
import {MatButtonModule} from '@angular/material/button';
import {FormsModule} from '@angular/forms';
import {MatInputModule} from '@angular/material/input';
import {MatFormFieldModule} from '@angular/material/form-field';
import { UserServerService } from '../../../server/user-server.service';
import { Booking } from '../../classes/Booking';
import { BookingServerService } from '../../../server/booking-server.service';
import { DialogBookingComponent } from '../dialog-booking/dialog-booking.component';
import { pipe } from 'rxjs';

export interface DialogData {
  animal: string;
  name: string;
}

@Component({
  selector: 'app-trip-panel',
  standalone: true,
  imports: [NgIf,NgFor,OurTripsComponent,
    MatFormFieldModule,
    MatInputModule,
    FormsModule,
    MatButtonModule,
    MatDialogTitle,
    MatDialogContent,
    MatDialogActions,
    MatDialogClose,
    
  ],
  templateUrl: './trip-panel.component.html',
  styleUrl: './trip-panel.component.css'
})
export class TripPanelComponent implements OnInit {


  name!: string;
  trip:Trip=new Trip();
  current: UserServerService | undefined;


  constructor(public server:TripServerService,public userServer:UserServerService ,public ar:ActivatedRoute,public dialog:MatDialog){
    this.current!=userServer.CurentUser;
  }
  
  
  ngOnInit(): void {
    this.current!=this.userServer.CurentUser
    const code=this.ar.snapshot.params['id']
    this.server.getById(code).subscribe(
      succ=>{this.trip=succ}
    )
    
  }
  //פתיחת חלונית הזמנת מקומות
  openDialog(id:number,name:string): void {
    //שליחת פרטי הטיול לקומפוננטה של הזמנת מקומות לטיול עי שימוש בדטה
    const dialogRef = this.dialog.open(DialogBookingComponent, {
      data: {id:id, name:name, },
    });
    dialogRef.afterClosed().subscribe(result => {
      console.log('The dialog was closed');
    });
  }
  bookTrip(){}
}

