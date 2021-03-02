import { Component, OnInit } from '@angular/core';
import { groupBy } from 'rxjs/internal/operators/groupBy';
import { TransactionService } from 'src/app/shared/transaction.service';
import { TransactionChartData } from 'src/app/shared/transactions.model';

@Component({
  selector: 'app-databoard',
  templateUrl: './databoard.component.html',
  styleUrls: ['./databoard.component.scss']
})
export class DataboardComponent implements OnInit {

  countryCasesChartOptions: any;
  transactionChartData : TransactionChartData[]= [];
  
  constructor(private transactionService:TransactionService) 
  {
   
  }

  ngOnInit(): void 
  {
    this.transactionService.getTrasactionsChartData().subscribe(
      data => 
      {
        this.transactionChartData = data;
        this.setChart();
      }
    );
   
  }

  setChart() {
    this.countryCasesChartOptions = {
      title: {
        text: 'Bilance',
      },
      legend: {
        data: ['Income', 'Expanse']
      },
      tooltip: {
      },
      xAxis: {
        data:   this.transactionChartData.map(x => new Date(x.date).toLocaleDateString()),
      },
      yAxis: {
        type: 'value'
      },
      series: [{
        name: 'Income',
        type: 'line',
        data: this.transactionChartData.map(x => x.amountIncome),
      },
      {
        name: 'Expanse',
        type: 'line',
        data: this.transactionChartData.map(x => x.amountExpense),
      },   
      ]
    };

    }
}
