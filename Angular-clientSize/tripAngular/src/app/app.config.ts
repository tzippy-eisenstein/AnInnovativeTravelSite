import { ApplicationConfig, importProvidersFrom } from '@angular/core';
import { provideRouter } from '@angular/router';
import { routes } from './app.routes';
import { provideClientHydration } from '@angular/platform-browser';
import { provideAnimations } from '@angular/platform-browser/animations';
import { UserServerService } from '../server/user-server.service';
import { HttpClientModule } from '@angular/common/http';
import { CommonModule } from '@angular/common';


export const appConfig: ApplicationConfig = {

  //צריך לעדכן פה את המשתנה importProvidersFrom(HttpClientModule)
  providers:[provideRouter(routes),importProvidersFrom(HttpClientModule),provideClientHydration(),UserServerService,CommonModule]
};
