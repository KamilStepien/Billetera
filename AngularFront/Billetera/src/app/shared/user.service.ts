import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { UserAuthenticateModel, UserModule, UserRegisterModel } from './user.module';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  public userlog: UserModule ;
  
  errormessage:string = "";
  
  
  constructor(private http:HttpClient,private router:Router ) { }

  
  register(model:UserRegisterModel) 
  {
    this.http.post("https://localhost:44364/user/register",model).subscribe
    (
      result => this.errormessage = "",
      error => this.errormessage = error.error.message
    )
  }

  authenticate(model:UserAuthenticateModel)
  {
    this.http.post<UserModule>("https://localhost:44364/user/authenticate", model).subscribe
    (
      result => {
        this.errormessage = "";
        this.router.navigate(['/transaction']);
        this.userlog = result;
      },
      error => this.errormessage = error.error.message
    )

  ;
  }
  


}
