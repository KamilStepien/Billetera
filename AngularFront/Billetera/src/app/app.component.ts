import { Component } from '@angular/core';
import {  Router } from '@angular/router';
import { TransactionService } from './shared/transaction.service';
import { UserService } from './shared/user.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'],
 
})
export class AppComponent 
{
  constructor(private router:Router, public service:UserService){}; 


  logOut()
  {
    this.service.logOut();
    this.router.navigate(["authenticate"]);
  }


}

