import { Component, signal } from '@angular/core';
import { WorkItemComponent } from './workitem/workitem';

@Component({
  imports: [WorkItemComponent],
  selector: 'app-root',
  styleUrl: './app.css',
  templateUrl: './app.html',
})
export class App {
  protected readonly title = signal('inv-gen-angular-client');
}
