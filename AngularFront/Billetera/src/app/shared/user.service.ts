import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { UserAuthenticateModel, UserEditModule, UserModule, UserRegisterModel } from './user.module';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  public userlog: UserModule;
  public IsLogUser: boolean = false;
  errormessage:string = "";
  
  
  constructor(private http:HttpClient,private router:Router ) { }

  cleanError()
  {
    this.errormessage = "";
  }

  logOut()
  {
    this.IsLogUser = false;
  }
  
  register(model:UserRegisterModel) 
  {
    this.http.post("https://localhost:44364/user/register",model).subscribe
    (
      result =>
      {
        this.router.navigate(['/authenticate']);
        this.errormessage = "";
      },
      error => this.errormessage = error.error.message
    )
  }

  authenticate(model:UserAuthenticateModel)
  {
    this.http.post<UserModule>("https://localhost:44364/user/authenticate", model).subscribe
    (
      result => {
        this.errormessage = "";
        this.router.navigate(['/dashboard']);
        this.userlog = result;
        this.IsLogUser = true;
      },
      error => this.errormessage = error.error.message
    )

  ;
  }

  putEditUser(model:UserEditModule)
  {
    model.id = this.userlog.id;
    this.http.put("https://localhost:44364/user/edit",model).subscribe
    (
      result => {
        this.errormessage = "";
        this.router.navigate(['/dashboard']);
        this.userlog.firstName = model.firstName;
        this.userlog.lastName = model.lastName;
        this.userlog.avatarLink = model.avatarLink;
      },
      error => this.errormessage = error.error.message
    )
    
  }
  


}
