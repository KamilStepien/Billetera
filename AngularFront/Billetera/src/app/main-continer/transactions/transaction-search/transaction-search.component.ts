import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { CategorieService } from 'src/app/shared/categorie.service';
import { TransactionService } from 'src/app/shared/transaction.service';
import { TransactionModel } from 'src/app/shared/transactions.model';

@Component({
  selector: 'app-transaction-search',
  templateUrl: './transaction-search.component.html',
  styleUrls: ['./transaction-search.component.scss']
})
export class TransactionSearchComponent implements OnInit {

  transactionSearch = new FormGroup({
    minMoney: new FormControl('',[Validators.required]),
    maxMoney: new FormControl('',[Validators.required]),
    categorieId: new FormControl('',[Validators.required]),

  })


  constructor(public categorieService:CategorieService, private transactionService:TransactionService) { }

  ngOnInit(): void {
   this.categorieService.getCategories();
  }

  submit()
  {
    this.transactionService.sortTransaction(this.transactionSearch.value);
  }

}
