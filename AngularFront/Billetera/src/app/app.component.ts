import { Component } from '@angular/core';
import { TransactionService } from './shared/transaction.service';
import { UserService } from './shared/user.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'],
 
})
export class AppComponent 
{
  constructor(public service:UserService){}; 
}
