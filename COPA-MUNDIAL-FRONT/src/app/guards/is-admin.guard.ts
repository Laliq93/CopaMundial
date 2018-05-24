import { Injectable } from '@angular/core';
import { CanLoad, ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';
import { Observable } from 'rxjs';
import { Router } from '@angular/router';
import { Route } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class IsAdminGuard implements CanLoad {

  constructor(public router: Router) {}

  canLoad(route: Route): boolean | Observable<boolean> | Promise<boolean> {
    //if (noEsAdmin) {
    //  this.router.navigate(['home']);
    //  return false
    //}
    return true;
  }

}
