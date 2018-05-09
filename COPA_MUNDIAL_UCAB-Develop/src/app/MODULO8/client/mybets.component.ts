import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'mybets',
  templateUrl: './mybets.component.html',
  styleUrls: ['./mybets.component.css']
})
export class MybetsComponent {
    public modulo: string = "ocho";
    constructor(private router: Router){}
	
}
