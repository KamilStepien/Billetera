import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { UserService } from 'src/app/shared/user.service';

@Component({
  selector: 'app-user-edit',
  templateUrl: './user-edit.component.html',
  styleUrls: ['./user-edit.component.scss']
})
export class UserEditComponent implements OnInit {


  user = new FormGroup(
    {
      actuallPassword: new FormControl('', [Validators.required]),
      newpassword:new FormControl('', [Validators.required]),
      firstName: new FormControl('', [Validators.required]),
      lastName: new FormControl('', [Validators.required]),
      avatarLink:new FormControl('', [Validators.required]),
      
    }
  )

  constructor(public userService:UserService) { }

  ngOnInit(): void {
    this.user.setValue({
      firstName:this.userService.userlog.firstName, 
      lastName:this.userService.userlog.lastName,
      avatarLink: this.userService.userlog.avatarLink,
      actuallPassword:"" ,
      newpassword:""})
  }

  submit()
  {
    this.userService.putEditUser(this.user.value);
  }

}
