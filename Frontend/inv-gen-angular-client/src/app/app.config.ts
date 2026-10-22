import {
  ApplicationConfig,
  inject,
  provideAppInitializer,
  provideBrowserGlobalErrorListeners
} from '@angular/core';
import { ConfigService } from './config/config.service';
import { provideHttpClient } from '@angular/common/http';
import { provideRouter } from '@angular/router';
import { routes } from './app.routes';

export const appConfig: ApplicationConfig = {
  providers: [
    provideBrowserGlobalErrorListeners(),
    provideHttpClient(),
    provideRouter(routes),

    provideAppInitializer(() => {
      const configService = inject(ConfigService);
      return configService.loadConfig();
    })
  ]
};
