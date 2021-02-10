import { Component, OnInit } from '@angular/core';
import { JarService } from 'src/app/shared/jar.service';

@Component({
  selector: 'app-jars-list',
  templateUrl: './jars-list.component.html',
  styleUrls: ['./jars-list.component.scss']
})
export class JarsListComponent implements OnInit {

  constructor(public jarService:JarService) { }

  ngOnInit(): void {
    this.jarService.getJars();
  }

}
