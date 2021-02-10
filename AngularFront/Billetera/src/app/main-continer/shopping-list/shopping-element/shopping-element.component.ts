import { CdkDragDrop, moveItemInArray } from '@angular/cdk/drag-drop';
import { Component, OnInit } from '@angular/core';
import { ShoppingListService } from 'src/app/shared/shopping-list.service';

@Component({
  selector: 'app-shopping-element',
  templateUrl: './shopping-element.component.html',
  styleUrls: ['./shopping-element.component.scss']
})
export class ShoppingElementComponent implements OnInit {

  constructor(public shoppingListService: ShoppingListService) { }

  ngOnInit(): void {

  }

  drop(event: CdkDragDrop<string[]>) {
    moveItemInArray(this.shoppingListService.shoppingListElements, event.previousIndex, event.currentIndex);
  }

}
