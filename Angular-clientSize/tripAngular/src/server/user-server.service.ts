import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { User } from '../app/classes/User';

@Injectable({
  providedIn: 'root'
})
export class UserServerService {
  maneger:User=new User();
  CurentUser: User= new User();
  isActiv:boolean=false;

  constructor(private http :HttpClient) {}
    
getAll():Observable<any> 
{ 
  return this.http.get<User>(`https://localhost:7138/api/user`);
}

 getByEmailAndPassword(email: string, password: string) {
  return this.http.get<User>(`https://localhost:7138/api/user/getByEmailAndPassword/${email}/${password}`);
  // return this.http.get<User>(`https://localhost:7138/api/user/getByEmailAndPassword/1/1`);

}
addUser(user:User)
{ 
  return this.http.post<User>(`https://localhost:7138/api/user/AddUser`,user);
}

GetAllTrips(id:number):Observable<any>  {
  return this.http.get<User>(`https://localhost:7138/api/user/GetAllTrips/${id}`);
  // return this.http.get<User>(`https://localhost:7138/api/user/getByEmailAndPassword/1/1`);

}
update(id:number|undefined,user:User):Observable<any>  {
  return this.http.put<User>(`https://localhost:7138/api/user/update/${id}`,user);
}
delete(id:number|undefined):Observable<any> {
  return this.http.delete<User>(`https://localhost:7138/api/user/deletUser/${id}`)
}
  // /api/user/upDate/8
// api/user/deletUser/233
}