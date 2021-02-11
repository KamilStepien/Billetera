import { Component, Input, OnInit } from '@angular/core';
import { NotificationModel } from 'src/app/shared/notification.module';
import { NotificationService } from 'src/app/shared/notification.service';

@Component({
  selector: 'app-notification-list-element',
  templateUrl: './notification-list-element.component.html',
  styleUrls: ['./notification-list-element.component.scss']
})
export class NotificationListElementComponent implements OnInit {

  constructor(private notificationService:NotificationService) { }

  @Input() notificationInput:NotificationModel

  ngOnInit(): void {
  }
  
  closeNotification(element:HTMLElement, id:number)
  {
    this.notificationService.postDeactiveNotification(id).subscribe(result => 
      {
        element.remove();
      })
  }
}
