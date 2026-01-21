import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class BaseAPI {
    private readonly BASE_URL = "https://montero-hzedh8ahesg5cceh.francecentral-01.azurewebsites.net";
    
    protected getBaseUrl(): string {
        return this.BASE_URL;
    }
}