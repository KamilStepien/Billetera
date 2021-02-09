import { Component, OnInit } from '@angular/core';
import { CategorieService } from 'src/app/shared/categorie.service';

@Component({
  selector: 'app-categorie-list',
  templateUrl: './categorie-list.component.html',
  styleUrls: ['./categorie-list.component.scss']
})
export class CategorieListComponent implements OnInit {

  constructor(public categorieService : CategorieService) { }

  ngOnInit(): void 
  {
    this.categorieService.getCategories();

  }

}
