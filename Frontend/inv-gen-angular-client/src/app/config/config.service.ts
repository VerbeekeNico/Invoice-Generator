import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { firstValueFrom } from 'rxjs';
import { AppConfig } from './app-config';

@Injectable({
  providedIn: 'root'
})
export class ConfigService {
  private config!: AppConfig;

  constructor(private http: HttpClient) {}

  async loadConfig(): Promise<void> {
    this.config = await firstValueFrom(
      this.http.get<AppConfig>('/config.json')
    );
  }

  get apiUrl(): string {
    return this.config.apiUrl;
  }
}