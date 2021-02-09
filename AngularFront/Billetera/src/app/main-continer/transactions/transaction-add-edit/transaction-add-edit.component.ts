import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { CategorieService } from 'src/app/shared/categorie.service';
import { TransactionService } from 'src/app/shared/transaction.service';

@Component({
  selector: 'app-transaction-add-edit',
  templateUrl: './transaction-add-edit.component.html',
  styleUrls: ['./transaction-add-edit.component.scss']
})
export class TransactionAddEditComponent implements OnInit {

  transactionId:string ;

  transaction = new FormGroup({
    id:new FormControl('',),
    categorieId:new FormControl('',[Validators.required]),
    title: new FormControl('',[Validators.required]),
    amount: new FormControl('',[Validators.required]),
    createDate: new FormControl('',[Validators.required]),
    isExpanse: new FormControl('',[Validators.required])
  }
  )



  constructor(private transactionService:TransactionService, private route: ActivatedRoute, public categorieService : CategorieService) { 
    this.route.params.subscribe(param => this.transactionId = param?.id);
    console.log(this.transactionId);
    if(this.transactionId != undefined)
    {
      this.transactionService.getTransaction(this.transactionId).subscribe(result => 
      {
        this.transaction.setValue({id: result.id, categorieId: result.categorie.id , title:result.title , amount: result.amount, createDate: result.createDate.toString().slice(0, 10), isExpanse: result.isExpanse==true});
      })
    }
  }
  
  
  ngOnInit(): void {
    this.categorieService.getCategories();
    console.log(this.categorieService.categories);
  }


  submit(id:string)
  {
    if(Number(id) == 0)
    {
      this.transactionService.postTransaction(this.transaction.value);
    }
    else
    {
      this.transactionService.putTransaction(this.transaction.value);
    }
  }


}
