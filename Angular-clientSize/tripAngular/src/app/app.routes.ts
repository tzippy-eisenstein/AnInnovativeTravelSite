import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './comps/home/home.component';
import { LoginComponent } from './comps/login/login.component';
import { RegisterComponent } from './comps/register/register.component';
import { OurTripsComponent } from './comps/our-trips/our-trips.component';
import { PersonalAreaComponent } from './comps/personal-area/personal-area.component';
import{ManegerComponent} from './comps/maneger/maneger.component'
import { TripPanelComponent } from './comps/trip-panel/trip-panel.component';


export const routes: Routes = [
 {path:'home',component:HomeComponent},
 {path:'login',component:LoginComponent},
 {path:'register',component:RegisterComponent},
 {path:'ourTrips',component:OurTripsComponent},
 {path:'personaleArea',component:PersonalAreaComponent},
 {path:'ManegerComponent',component:ManegerComponent},
 {path:'TripPanel/:id',component:TripPanelComponent},

];


