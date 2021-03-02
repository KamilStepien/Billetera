import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import {  NotificationModel } from './notification.module';
import { UserService } from './user.service';

@Injectable({
  providedIn: 'root'
})
export class NotificationService {

  notifications: NotificationModel []

  constructor(private http:HttpClient, private userService:UserService) { }


  getNotification()
  {
    this.http.get<NotificationModel[]>("https://localhost:44364/notification/user/"+ this.userService.userlog.id ).subscribe(
      data => this.notifications = data
    );
  }


  postDeactiveNotification(id:number):Observable<any>
  {
    return this.http.post("https://localhost:44364/notification/deactive-notyfication/"+id,null)
  }

}
