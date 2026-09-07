import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment';
import { WorkItem } from './workitem.model';

@Injectable({ providedIn: 'root' })
export class WorkItemService {
  private readonly http = inject(HttpClient);
  private readonly workItemsUrl = `${environment.apiUrl}/api/WorkItems`;

  getWorkItems(): Observable<WorkItem[]> {
    return this.http.get<WorkItem[]>(this.workItemsUrl);
  }
}