import { Component, Input, OnInit } from '@angular/core';
import { TransactionModel } from 'src/app/shared/transactions.model';

@Component({
  selector: 'app-transactions-list-element',
  templateUrl: './transactions-list-element.component.html',
  styleUrls: ['./transactions-list-element.component.scss']
})
export class TransactionsListElementComponent implements OnInit {

  @Input() transactionInput: TransactionModel;

  ngOnInit(): void {
  }

  deleteTransaction(element:HTMLElement, id:string)
  {
    element.remove();
    console.log(id);
  }
}
