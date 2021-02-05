import { Component, OnInit } from '@angular/core';
import { TransactionService } from 'src/app/shared/transaction.service';

@Component({
  selector: 'app-transactions-list',
  templateUrl: './transactions-list.component.html',
  styleUrls: ['./transactions-list.component.scss']
})
export class TransactionsListComponent implements OnInit {

  constructor(public service:TransactionService) { }

  ngOnInit(): void 
  {
    this.service.getTransactions();
  }


  

}
