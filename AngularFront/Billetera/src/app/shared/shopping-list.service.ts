import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ShoppingListElementAddModel, ShoppingListElementModel } from './shoppingListElement.model';
import { UserService } from './user.service';

@Injectable({
  providedIn: 'root'
})
export class ShoppingListService {


  shoppingListElements : ShoppingListElementModel []

  constructor(private http: HttpClient, private userService:UserService) { }


  getShoppingListElements()
  {
    this.http.get<ShoppingListElementModel[]>("https://localhost:44364/shoppingListElement/user/"+ this.userService.userlog.id).subscribe(
      data => this.shoppingListElements = data
    )
  }

  deleteShoppingListElement(id:number):Observable<object>
  {
    return this.http.delete("https://localhost:44364/shoppingListElement/"+id);
  }

  postShoppingListElement(model:ShoppingListElementAddModel)
  {
    model.userId = this.userService.userlog.id
    model.sequence = this.shoppingListElements.length;
    return this.http.post<ShoppingListElementModel>("https://localhost:44364/shoppingListElement", model).subscribe(
      result => this.shoppingListElements.push(result)
    )
  }

  setSequence()
  {
    this.http.put("https://localhost:44364/shoppingListElement/setSequence",this.shoppingListElements).subscribe();
  }

}
