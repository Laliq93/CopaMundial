 import { Component, OnInit } from '@angular/core';
 //declare var jquery:any;
 declare var $ :any;


@Component({
  selector: 'statistic',
  templateUrl: './statistic.component.html',
  styleUrls: ['./statistic.component.css']
})
export class StatisticComponent implements OnInit{




  ngOnInit(): void {
    
        $("#picker").pickdate();
  
  }
    public modulo: string = "nueve"; 
  
}

