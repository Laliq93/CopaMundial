 import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
 declare var jquery:any;
 declare var $ :any;


@Component({
  selector: 'statistic',
  templateUrl: './statistic.component.html',
  styleUrls: ['./statistic.component.css']
})
export class StatisticComponent implements OnInit{


  constructor(private router: Router){}


  ngOnInit(): void {
    
        $("#picker").pickdate();
  
  }
    public modulo: string = "nueve"; 
  
    estPartidos(){

    }
}

