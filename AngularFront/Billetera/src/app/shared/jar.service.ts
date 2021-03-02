import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { JarAddModel, JarAddMoneyModel, JarEditModel, JarEndModel, JarModel } from './jar.module';
import { UserService } from './user.service';

@Injectable({
  providedIn: 'root'
})
export class JarService {


  jars: JarModel[]

  constructor(private http:HttpClient , private router:Router, private userService:UserService) { }

  getJars()
  {
    this.http.get<JarModel[]>("https://localhost:44364/jar/user/" + this.userService.userlog.id ).subscribe(
      data => this.jars = data
    );
  }

  getJar(id:string):Observable<JarModel>
  {
    return this.http.get<JarModel>("https://localhost:44364/jar/"+id)
  }

  postAddMoneyJat(model:JarAddMoneyModel):Observable<any>
  {
    return this.http.post("https://localhost:44364/jar/add-money",model)
  }

  postJar(model:JarAddModel)
  {
    model.userId = this.userService.userlog.id;
    this.http.post<JarModel>("https://localhost:44364/jar", model).subscribe(
      result => 
      {
        this.router.navigate(["jar"]);
      }
    );
  }

  putJar(model:JarEditModel)
  {
    model.userId = this.userService.userlog.id;

    this.http.put<JarModel>("https://localhost:44364/jar", model).subscribe(
      result => 
      {
        this.router.navigate(["jar"]);
      }
    );
  }

  postEndJar(jarId:number)
  {
    let model:JarEndModel = 
    {
      id:jarId,
      userId: this.userService.userlog.id

    }
    this.http.post("https://localhost:44364/jar/end", model).subscribe(
      result => 
      {
        this.getJars();
      }
    );
  }


}
