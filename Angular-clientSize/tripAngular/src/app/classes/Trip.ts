export class Trip{
    constructor(
         public  idTrip?:number,
         public destinationTrip?:string,
         public idType?:number,
         public dateTrip?:Date,
         public leavingTime?:number,
         public durationTrip?:number,
         public placesAvailable?:number,
         public price?:number,
         public image?:string,
         public typeName?:string,
         ) {
    }
}