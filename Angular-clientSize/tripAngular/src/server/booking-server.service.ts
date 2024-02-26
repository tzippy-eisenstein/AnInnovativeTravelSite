import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Booking } from '../app/classes/Booking';

@Injectable({
  providedIn: 'root'
})
export class BookingServerService {

  constructor(private http:HttpClient) { }

  delete(id:number):Observable<any>{
    return this.http.delete<Booking>(`https://localhost:7138/api/trip/deleteBooking/${id}`)
  }

  getBookingById(id:number):Observable<any>{
    return this.http.get<Booking>(`https://localhost:7138/api/trip/getBookingById/${id}`)
  }

  add(Booking:Booking ):Observable<any>{
    return this.http.post<Booking>(`https://localhost:7138/api/trip/addBooking`,Booking)
  }

}
