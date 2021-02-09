import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { TransferState } from '@angular/platform-browser';
import { Observable } from 'rxjs';
import { TransactionAddModel, TransactionChartData, TransactionEditModel, TransactionModel } from './transactions.model';
import { UserService } from './user.service';


@Injectable({
  providedIn: 'root'
})
export class TransactionService {

  transactions:TransactionModel[] = [];
 

  constructor(private http:HttpClient,  private userService: UserService) { }


  getTransactions()
  {
    this.http.get<TransactionModel[]>("https://localhost:44364/transaction/user/" + this.userService.userlog.id ).subscribe(
      data => this.transactions = data
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
    var tmp = 
    {
      CategorieID: Number(model.categorieId),
      UserID:this.userService.userlog.id,
      Title: model.title,
      CreateDate:model.createDate,
      Amount:model.amount,
      IsExpense:Boolean(model.isExpanse)
    }

    console.log(tmp);
    this.http.post<TransactionModel>("https://localhost:44364/transaction/", tmp).subscribe(
      result => 
      {
        console.log(result);
      }
    );
  }

  putTransaction(model:TransactionEditModel)
  {
    var tmp = 
    {
      ID: model.id,
      CategorieID: model.categorieId,
      UserID:this.userService.userlog.id,
      Title: model.title,
      CreateDate:model.createDate,
      Amount:model.amount,
      IsExpense:model.isExpanse == true
    }

    this.http.put<TransactionModel>("https://localhost:44364/transaction/", tmp).subscribe(
      result => 
      {
        console.log(result);
      }
    );
  }
  

  delete(id:string):Observable<any>
  {
    return this.http.delete("https://localhost:44364/transaction/" + id );
  }

}
