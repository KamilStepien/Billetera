import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { JarService } from 'src/app/shared/jar.service';

@Component({
  selector: 'app-jars-add-edit',
  templateUrl: './jars-add-edit.component.html',
  styleUrls: ['./jars-add-edit.component.scss']
})
export class JarsAddEditComponent implements OnInit {

  jarId:string ;

  jar = new FormGroup(
    {
      id: new FormControl(''),
      name: new FormControl('',[Validators.required]),
      endDate: new FormControl('',[Validators.required]),
      aim: new FormControl('',[Validators.required]),
    }
  );


  constructor(private jarService:JarService, private route:ActivatedRoute) { 
    this.route.params.subscribe(param => this.jarId = param?.id);
    if(this.jarId != undefined)
    {
      this.jarService.getJar(this.jarId).subscribe(result => 
      {
        this.jar.setValue({id: result.id, name: result.name , endDate: result.endDate.toString().slice(0, 10), aim: result.aim});
      })
    }
  }

  ngOnInit(): void {
  }

  submit(id:string)
  {
    if(Number(id) == 0)
    {
      this.jarService.postJar(this.jar.value);
    }
    else
    {
      this.jarService.putJar(this.jar.value);
    }
  }

}
