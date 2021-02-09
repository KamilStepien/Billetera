import { Component, Input, OnInit } from '@angular/core';
import { CategorieService } from 'src/app/shared/categorie.service';
import { CategorieModel } from 'src/app/shared/categories.module';

@Component({
  selector: 'app-categorie-list-element',
  templateUrl: './categorie-list-element.component.html',
  styleUrls: ['./categorie-list-element.component.scss']
})
export class CategorieListElementComponent implements OnInit {

  @Input() categorieInput: CategorieModel;

  constructor(private categoryService: CategorieService) { }

  ngOnInit(): void {
  }

  deleteCategory(element:HTMLElement, id:string)
  {

    console.log()

     this.categoryService.delete(id).subscribe(result => 
      {
        element.remove();
      })
  }

}
