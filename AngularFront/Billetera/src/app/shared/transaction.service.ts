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
    
    model.userId = this.userService.userlog.id;

    this.http.post<TransactionModel>("https://localhost:44364/transaction/", model).subscribe(
      result => 
      {
        console.log(result);
      }
    );
  }

  putTransaction(model:TransactionEditModel)
  {
    
    model.userId = this.userService.userlog.id;

    this.http.put<TransactionModel>("https://localhost:44364/transaction/", model).subscribe(
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
