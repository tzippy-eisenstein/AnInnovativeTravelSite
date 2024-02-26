import { mergeApplicationConfig, ApplicationConfig } from '@angular/core';
import { provideServerRendering } from '@angular/platform-server';
import { appConfig } from './app.config';
import { UserServerService } from '../server/user-server.service';
import { CommonModule } from '@angular/common';

const serverConfig: ApplicationConfig = {
  providers: [
    provideServerRendering()
    
  ]
};

export const config = mergeApplicationConfig(appConfig, serverConfig,);
