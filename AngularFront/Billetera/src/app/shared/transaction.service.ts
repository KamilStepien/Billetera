import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { TransferState } from '@angular/platform-browser';
import { Observable } from 'rxjs';
import { TransactionAddModel, TransactionChartData, TransactionEditModel, TransactionModel, TransactionSearchModel } from './transactions.model';
import { UserService } from './user.service';


@Injectable({
  providedIn: 'root'
})
export class TransactionService {

  transactions:TransactionModel[] = [] ;
  transactionsCopy:TransactionModel[] = [] ;

  constructor(private http:HttpClient,  private userService: UserService) { }



  sortTransaction(model:TransactionSearchModel)
  {
    let newTransactions: TransactionModel[] = []
    this.transactionsCopy.forEach(x=>{
      if((model.minMoney<= x.amount && model.maxMoney >= x.amount && model.categorieId == x.categorie.id ))
      newTransactions.push(x);
    })

    this.transactions = newTransactions;
  }

  getTransactions()
  {
    this.http.get<TransactionModel[]>("https://localhost:44364/transaction/user/" + this.userService.userlog.id ).subscribe(
      data => 
      {
        this.transactions = data;
        this.transactionsCopy = data;
      }
      
    );
   
  }

  getTrasactionsChartData()
  {
    return  this.http.get<TransactionChartData[]>("https://localhost:44364/transaction/user/" + this.userService.userlog.id + "/chardata" )
  }

  getTransaction(id:string): Observable<TransactionModel>
  {
    return this.http.get<TransactionModel>("https://localhost:44364/transaction/" + id )
   
  }

  postTransaction(model:TransactionAddModel)
  {
    
    let tmp = 
    {
      amount: model.amount,
      categorieId: model.categorieId,
      createDate: model.createDate,
      isExpense: Boolean(model.isExpense == "true")  ,
      title: model.title,
      userId : this.userService.userlog.id

    }

    this.http.post<TransactionModel>("https://localhost:44364/transaction/", tmp).subscribe();
  }

  putTransaction(model:TransactionEditModel)
  {
    let tmp = 
    {
      id:model.id,
      amount: model.amount,
      categorieId: model.categorieId,
      createDate: model.createDate,
      isExpense: Boolean(model.isExpense == "true")  ,
      title: model.title,
      userId : this.userService.userlog.id

    }
    this.http.put<TransactionModel>("https://localhost:44364/transaction/", tmp).subscribe();
  }
  

  delete(id:string):Observable<any>
  {
    return this.http.delete("https://localhost:44364/transaction/" + id );
  }

}
