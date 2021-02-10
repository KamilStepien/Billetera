import { Component, OnInit } from '@angular/core';
import { JarService } from 'src/app/shared/jar.service';

@Component({
  selector: 'app-jars',
  templateUrl: './jars.component.html',
  styleUrls: ['./jars.component.scss']
})
export class JarsComponent implements OnInit {

  constructor(private jarService:JarService) { }

  ngOnInit(): void {
    this.jarService.getJars();
  }

}
