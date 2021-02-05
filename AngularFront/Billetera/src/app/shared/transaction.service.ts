import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { TransferState } from '@angular/platform-browser';
import { Observable } from 'rxjs';
import { TransactionAddModel, TransactionEditModel, TransactionModel } from './transactions.model';
import { UserService } from './user.service';


@Injectable({
  providedIn: 'root'
})
export class TransactionService {

  transactions:TransactionModel[] = [];

  constructor(private http:HttpClient,  private userService: UserService) { }


  getTransactions(userId:number)
  {
    return this.http.get<TransactionModel[]>("https://localhost:44364/transaction/user/" + userId ).subscribe(
      data => this.transactions = data
    );
   
  }

  getTransaction(id:string): Observable<TransactionModel>
  {
    return this.http.get<TransactionModel>("https://localhost:44364/transaction/" + id )
   
  }

  getPost(model:TransactionAddModel)
  {
    var tmp = 
    {
      CategorieID: model.categorieId,
      UserID:this.userService.userlog.id,
      Title: model.title,
      CreateDate:model.createDate,
      Amount:model.amount,
      IsExpense:model.isExpanse == true
    }

    console.log(tmp);
    this.http.post<TransactionModel>("https://localhost:44364/transaction/", tmp).subscribe(
      result => 
      {
        console.log(result);
        this.transactions.push(result);
      }
    );
  }

  getPut(model:TransactionEditModel): Observable<TransactionModel>
  {
    return this.http.put<TransactionModel>("https://localhost:44364/transaction/", model);
  }
  

  delete(id:string):Observable<any>
  {
    return this.http.delete("https://localhost:44364/transaction/" + id );
  }

}
