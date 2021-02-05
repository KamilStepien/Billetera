import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { TransactionModel } from './transactions.model';
import { UserService } from './user.service';


@Injectable({
  providedIn: 'root'
})
export class TransactionService {

  transactions:TransactionModel[] = [];

  constructor(private http:HttpClient, private userService: UserService) { }


  getTransactions()
  {
    return this.http.get<TransactionModel[]>("https://localhost:44364/transaction/user/1/"+ this.userService.userlog.token ).subscribe(
      data => this.transactions = data
    );
   
  }

}
