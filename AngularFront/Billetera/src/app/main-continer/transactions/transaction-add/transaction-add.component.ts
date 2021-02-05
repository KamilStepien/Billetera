import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { TransactionService } from 'src/app/shared/transaction.service';
import { UserService } from 'src/app/shared/user.service';

@Component({
  selector: 'app-transaction-add',
  templateUrl: './transaction-add.component.html',
  styleUrls: ['./transaction-add.component.scss']
})
export class TransactionAddComponent {


  addTransaction = new FormGroup({
    categorieId:new FormControl('',[Validators.required]),
    title: new FormControl('',[Validators.required]),
    amount: new FormControl('',[Validators.required]),
    createDate: new FormControl('',[Validators.required]),
    isExpanse: new FormControl('')
  }
  )



  constructor(private transactionService:TransactionService) { }


  submit()
  {
    this.transactionService.getPost(this.addTransaction.value);
  }

}
