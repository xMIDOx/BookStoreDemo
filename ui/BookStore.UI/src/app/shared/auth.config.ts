import { AuthConfig } from 'angular-oauth2-oidc';

export const authConfig: AuthConfig = {
  issuer: 'https://demo.duendesoftware.com', // IdP
  redirectUri: window.location.origin,
  clientId: 'interactive.public.short',
  responseType: 'code',
  scope: 'openid profile email api', // what we request
  showDebugInformation: true
};
