import { Component } from '@angular/core';
import {RouterModule, Router } from '@angular/router';

@Component({
  selector: 'bet',
  templateUrl: './bet.component.html',
  styleUrls: ['./bet.component.css']
})
export class BetComponent {

    public modulo: string = "ocho";
    constructor(private router: Router){}

    goMybets(): void {
      this.router.navigate(['home/bet/mybets']);
    }	

}
