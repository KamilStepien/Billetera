import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { CategorieService } from 'src/app/shared/categorie.service';

@Component({
  selector: 'app-categories-add',
  templateUrl: './categories-add.component.html',
  styleUrls: ['./categories-add.component.scss']
})
export class CategoriesAddComponent implements OnInit {

  constructor(private categorieService: CategorieService ) { }

  categorie = new FormGroup({
    name:new FormControl('',[Validators.required]),

  }
  )

  ngOnInit(): void {


  }

  submit()
  {
    this.categorieService.postCategorie(this.categorie.value);
  }

}
