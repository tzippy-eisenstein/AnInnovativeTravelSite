
export class Booking{
    constructor(
         public idBooking?:number,
         public idUser?:number,
         public dateBookink?:Date,
         public timeBooking?:number,
         public idTrip?:number,
         public places?:number,
         public fullName?:string,
         public tripName?:string,
         public dateTrip?:Date 
         ) {
    }
}