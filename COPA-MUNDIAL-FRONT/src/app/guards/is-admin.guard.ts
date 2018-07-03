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
    console.log('prueba esAdmin guard');
    if(localStorage.getItem('esAdmin') != null){
      this.router.navigate(['/inicio', 'admin']);
      return true;
    }

    console.log('no entro en el if del admin');

    this.router.navigate(['/inicio', 'login']);
    return false;
  }

}
