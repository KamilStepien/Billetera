import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { JarService } from 'src/app/shared/jar.service';

@Component({
  selector: 'app-add-money-to-jar',
  templateUrl: './add-money-to-jar.component.html',
  styleUrls: ['./add-money-to-jar.component.scss']
})
export class AddMoneyToJarComponent implements OnInit {


  addMoneyToJar = new FormGroup(
    {
      money: new FormControl('',[Validators.required, Validators.min(0)]),
      jarId: new FormControl('',[Validators.required])
    }
  )

  constructor(public jarService:JarService) { }

  ngOnInit(): void {
  }

  submit()
  {
    this.jarService.postAddMoneyJat(this.addMoneyToJar.value).subscribe(
      result => this.jarService.getJars()
    );
  }

}
