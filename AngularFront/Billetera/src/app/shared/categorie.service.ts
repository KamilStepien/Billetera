import { DatePipe } from '@angular/common';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { CategorieAddModel, CategorieModel } from './categories.module';
import { UserService } from './user.service';

@Injectable({
  providedIn: 'root'
})
export class CategorieService {

  constructor(private http:HttpClient,  private userService: UserService) { }

  categories:CategorieModel[];

  
  postCategorie(model:CategorieAddModel)
  {

    var tmp = 
    {
      Name: model.name,
      UserID:this.userService.userlog.id,
     
    }
    console.log(tmp);
    this.http.post<CategorieModel>("https://localhost:44364/categorie/", tmp).subscribe(
      result => 
      {
        console.log(result);
        
      }
    );
  }
  
  getCategories()
  {
    this.http.get<CategorieModel[]>("https://localhost:44364/categorie/user/"+ this.userService.userlog.id).subscribe(
      result => this.categories  = result
      
    );
  }

  delete(id:string):Observable<any>
  {
    return this.http.delete("https://localhost:44364/categorie/" + id );
  }
}
