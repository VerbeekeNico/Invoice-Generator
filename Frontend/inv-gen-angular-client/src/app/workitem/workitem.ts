import { Component, OnInit, signal } from '@angular/core';
import { WorkItemService } from './workitem.service';
import { WorkItem } from './workitem.model';
import { DatePipe } from '@angular/common';

@Component({
  selector: 'app-workitem',
  imports: [DatePipe],
  templateUrl: './workitem.html',
  styleUrl: './workitem.css',
})

export class WorkItemComponent implements OnInit {

  workItems = signal<WorkItem[]>([]);

  constructor(private workItemService: WorkItemService) {
  }

  ngOnInit(): void {
    this.loadWorkItems();
  }

  loadWorkItems(): void {
    this.workItemService.getWorkItems()
      .subscribe(items => {
        console.log('Received:', items);
        console.log('Count:', items.length);
        this.workItems.set(items);
      });
  }
}