import { Component, Input, OnInit } from '@angular/core';
import { JarModel } from 'src/app/shared/jar.module';
import { JarService } from 'src/app/shared/jar.service';

@Component({
  selector: 'app-jar-list-element',
  templateUrl: './jar-list-element.component.html',
  styleUrls: ['./jar-list-element.component.scss']
})
export class JarListElementComponent implements OnInit {


  @Input() jarInput:JarModel

  constructor(private jarService:JarService) { }

  ngOnInit(): void {
  }

  jarEnd(id:number)
  {
    this.jarService.postEndJar(id)
  }

}
