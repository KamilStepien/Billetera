import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ShoppingListService } from 'src/app/shared/shopping-list.service';

@Component({
  selector: 'app-shopping-element-add',
  templateUrl: './shopping-element-add.component.html',
  styleUrls: ['./shopping-element-add.component.scss']
})
export class ShoppingElementAddComponent implements OnInit {

  constructor(private shoppingListService:ShoppingListService) { }



  shoppingElement = new FormGroup({
    description: new  FormControl('',[Validators.required])
  });

  ngOnInit(): void {
  }

  submit()
  {
     this.shoppingListService.postShoppingListElement(this.shoppingElement.value);
  }

}
