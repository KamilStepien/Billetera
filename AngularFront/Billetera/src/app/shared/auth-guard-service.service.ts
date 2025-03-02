import { Injectable } from '@angular/core';
import { Router, CanActivate, ActivatedRouteSnapshot,RouterStateSnapshot } from '@angular/router';
import { UserService } from './user.service';
 
 
@Injectable()
export class AuthGuardService implements CanActivate {
 
    constructor(private router:Router, private userService:UserService ) {
    }
 
    canActivate(route: ActivatedRouteSnapshot,
                state: RouterStateSnapshot): boolean {

        if (!this.userService.IsLogUser)  {
            this.router.navigate(["authenticate"]);
            return false;
        } 
        return true;
    }
 
}