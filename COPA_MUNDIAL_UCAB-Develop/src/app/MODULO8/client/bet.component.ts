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

    mybets(): void {
      this.router.navigate(['mybets']);
    }	

}
