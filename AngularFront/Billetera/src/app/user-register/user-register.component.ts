import { error } from '@angular/compiler/src/util';
import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { UserService } from '../shared/user.service';

@Component({
  selector: 'app-user-register',
  templateUrl: './user-register.component.html',
  styleUrls: ['./user-register.component.scss']
})
export class UserRegisterComponent {

  
  userRegister = new FormGroup({
    email:new FormControl('',[Validators.required]),
    password:new FormControl('',[Validators.required]),
    firstName: new FormControl('',[Validators.required]),
    lastName: new FormControl('',[Validators.required])
  }
  )

  constructor(public service: UserService) { }

  registerUser()
  { 
    this.service.register(this.userRegister.value);
  }


}
