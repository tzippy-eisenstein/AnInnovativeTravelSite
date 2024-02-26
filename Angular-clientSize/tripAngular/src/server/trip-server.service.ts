import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Trip } from '../app/classes/Trip';
import { Observable } from 'rxjs/internal/Observable';
import { TripsType } from '../app/classes/TripsType';

@Injectable({
  providedIn: 'root'
})
export class TripServerService {

  constructor(private http :HttpClient) {}

  getAll():Observable<any> 
{ 
  return this.http.get<Trip>(`https://localhost:7138/api/trip/GetAllTrip`);
}
getById(id:number) :Observable<any>
{ 
  return this.http.get<Trip>(`https://localhost:7138/api/trip/GetAllTripById/${id}`);
}
getTripType( ):Observable<any> 
{ 
  return this.http.get<TripsType>(`https://localhost:7138/api/trip/getAllTripsTypes`);
}

}
