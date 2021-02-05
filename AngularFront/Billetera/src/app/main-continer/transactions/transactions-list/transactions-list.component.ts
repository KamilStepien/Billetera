import { Component, OnInit } from '@angular/core';
import { TransactionService } from 'src/app/shared/transaction.service';
import { TransactionModel } from 'src/app/shared/transactions.model';
import { UserService } from 'src/app/shared/user.service';

@Component({
  selector: 'app-transactions-list',
  templateUrl: './transactions-list.component.html',
  styleUrls: ['./transactions-list.component.scss']
})
export class TransactionsListComponent implements OnInit {

  constructor(public service:TransactionService, public userService:UserService) { }

  ngOnInit(): void 
  {
    this.service.getTransactions(this.userService.userlog.id)

  }

}
