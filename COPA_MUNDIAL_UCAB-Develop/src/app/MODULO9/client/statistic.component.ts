import { Component, OnInit } from '@angular/core';
import * as $ from 'jquery';
import { Router } from '@angular/router';

@Component({
  selector: 'statistic',
  templateUrl: './statistic.component.html',
  styleUrls: ['./statistic.component.css']
})
export class StatisticComponent {
	constructor(private router: Router){}

	torneo(): void {
    this.router.navigate(['home/torneo']);
  
	}	
}
