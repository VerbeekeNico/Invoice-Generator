import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { WorkItem } from './workitem.model';
import { ConfigService } from '../config/config.service';

@Injectable({ providedIn: 'root' })
export class WorkItemService {
  private readonly http = inject(HttpClient);
  private readonly workItemsUrl = `${inject(ConfigService).apiUrl}/WorkItems`;

  getWorkItems(): Observable<WorkItem[]> {
    return this.http.get<WorkItem[]>(this.workItemsUrl);
  }
}