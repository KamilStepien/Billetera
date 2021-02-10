import { Component, OnDestroy, OnInit } from '@angular/core';
import { ShoppingListService } from 'src/app/shared/shopping-list.service';

@Component({
  selector: 'app-shopping-list',
  templateUrl: './shopping-list.component.html',
  styleUrls: ['./shopping-list.component.scss']
})
export class ShoppingListComponent implements OnInit, OnDestroy {

  constructor(private shoppingListService:ShoppingListService) { }
  
 

  ngOnInit(): void {
    this.shoppingListService.getShoppingListElements();
  }
  
  ngOnDestroy(): void {
    this.shoppingListService.setSequence();
  }


}
