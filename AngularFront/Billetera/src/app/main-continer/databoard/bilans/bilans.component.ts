import { Component, OnInit } from '@angular/core';
import { TransactionService } from 'src/app/shared/transaction.service';

@Component({
  selector: 'app-bilans',
  templateUrl: './bilans.component.html',
  styleUrls: ['./bilans.component.scss']
})
export class BilansComponent implements OnInit {

  constructor(private transactionService:TransactionService) { }
  
  public increase:number = 0;
  public balance:number = 0;
  public expenses:number = 0;

  ngOnInit(): void {
    this.transactionService.getTransactions();
    this.setValue();
  }

  setValue()
  {
    this.increase = this.transactionService.transactions.filter(x=> Boolean(x.isExpense)==false).reduce((acc,cur)=> acc + cur.amount,0);
    this.expenses = this.transactionService.transactions.filter(x=>  Boolean(x.isExpense)==true).reduce((acc,cur)=> acc + cur.amount,0);
    this.balance = this.increase - this.expenses;
  }

}
