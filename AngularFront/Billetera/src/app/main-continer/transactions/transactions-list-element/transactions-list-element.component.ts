import { Component, Input, OnInit } from '@angular/core';
import { TransactionService } from 'src/app/shared/transaction.service';
import { TransactionModel } from 'src/app/shared/transactions.model';

@Component({
  selector: 'app-transactions-list-element',
  templateUrl: './transactions-list-element.component.html',
  styleUrls: ['./transactions-list-element.component.scss']
})
export class TransactionsListElementComponent  {

  @Input() transactionInput: TransactionModel;

  constructor(private service:TransactionService){}

  deleteTransaction(element:HTMLElement, id:string)
  {
     this.service.delete(id).subscribe(result => 
      {
        element.remove();
      })
  }
  
}
