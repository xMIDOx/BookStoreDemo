import { provideHttpClient, withInterceptorsFromDi } from '@angular/common/http';
import {
  APP_INITIALIZER,
  ApplicationConfig,
  provideBrowserGlobalErrorListeners,
  provideZoneChangeDetection,
} from '@angular/core';
import { provideRouter } from '@angular/router';
import { OAuthService, provideOAuthClient } from 'angular-oauth2-oidc';

import { initAuth } from './app';
import { routes } from './app.routes';
import { AuthInterceptor } from './shared/AuthInterceptor';


export const appConfig: ApplicationConfig = {
  providers: [
    provideBrowserGlobalErrorListeners(),
    provideZoneChangeDetection({ eventCoalescing: true }),
    provideRouter(routes),

    // HttpClient with DI interceptors enabled
    provideHttpClient(withInterceptorsFromDi()),

    // --- OAuth providers ---
    provideOAuthClient(),
    {
      provide: APP_INITIALIZER,
      useFactory: initAuth,
      deps: [OAuthService],
      multi: true
    },

    // Register your interceptor in DI
    AuthInterceptor
  ]
};
