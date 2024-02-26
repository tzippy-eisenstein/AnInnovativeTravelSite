import { Component, Inject } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MAT_DIALOG_DATA, MatDialogActions, MatDialogClose, MatDialogContent, MatDialogRef, MatDialogTitle } from '@angular/material/dialog';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
// import { UserServerService } from '../../../server/user-server.service';
import { UserServerService } from '../../../server/user-server.service';
// import { Booking } from '../../classes/Booking';
import { Booking } from '../../classes/Booking';
// import { Trip } from '../../classes/Trip';
// import { BookingServerService } from '../../../server/booking-server.service';
import { BookingServerService } from '../../../server/booking-server.service';
import { Trip } from '../../classes/Trip';
import { ActivatedRoute } from '@angular/router';
import { DatePipe } from '@angular/common';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-dialog-booking',
  standalone: true,
  imports: [
    MatFormFieldModule,
    MatInputModule,
    FormsModule,
    MatButtonModule,
    MatDialogTitle,
    MatDialogContent,
    MatDialogActions,
    MatDialogClose,
  ],
  templateUrl: './dialog-booking.component.html',
  styleUrl: './dialog-booking.component.css'
})
export class DialogBookingComponent {
  current:UserServerService| undefined
  order:Booking =new Booking();
  trip:Trip=new Trip();
  constructor(
    //קבלת נתונים בהזרקה מקומפוננטה
    @Inject(MAT_DIALOG_DATA) public data: any,
    public dialogRef: MatDialogRef<DialogBookingComponent>,
    public server:UserServerService,
    public bookingServer:BookingServerService,
    public ar:ActivatedRoute,
  ) {
    this.current=server
  }
  onNoClick(): void {
    this.dialogRef.close();
  }
  submitRegistrationForm(){

  }
  //פונקצית הזמנת המקומות
  orderf(){
    debugger
       this.order.dateBookink!=new Date(),
       this.order.idUser=this.server.CurentUser.idUser
       this.order.idTrip=this.data.id;
       this.order.tripName=this.data.name;
       this.order.timeBooking=DatePipe.toString.length
       this.order.fullName = `${this.server.CurentUser.userFirstName} ${this.server.CurentUser.userFirstName}`;
  this.bookingServer.add(this.order).subscribe(
    a => {
      if (a == true) {
        Swal.fire('Success!', 'ההזמנה נקלטה בהצלחה', 'success');
      } else {
        Swal.fire('Oops!', 'לא נשארו מספיק מקומות', 'error');
      }
    },
    b => {
      Swal.fire('Error!', 'Faild', 'error');
    }
    )
  }
}
 




 