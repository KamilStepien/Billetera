import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { UserService } from '../shared/user.service';

@Component({
  selector: 'app-user-authenticate',
  templateUrl: './user-authenticate.component.html',
  styleUrls: ['./user-authenticate.component.scss']
})
export class UserAuthenticateComponent implements OnInit{
  errormessage:string = "";
  userAuthenticate = new FormGroup({
    email:new FormControl('',[Validators.required]),
    password:new FormControl('',[Validators.required]),
    
  }
  )

  constructor(public service: UserService) { }
 
  ngOnInit(): void {
    this.service.cleanError();
  }

  authenticateUser()
  {
    this.service.authenticate(this.userAuthenticate.value);
  }

}
