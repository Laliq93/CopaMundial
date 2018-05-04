import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'bet',
  templateUrl: './bet.component.html',
  styleUrls: ['./bet.component.css']
})
export class BetComponent {
    public modulo: string = "ocho";
    constructor(private router: Router){}

    bets(): void {
      this.router.navigate(['bets']);
    }	
}
