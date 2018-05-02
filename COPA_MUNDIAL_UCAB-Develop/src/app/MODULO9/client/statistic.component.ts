import { Component, OnInit } from '@angular/core';
import * as $ from 'jquery';



@Component({
  selector: 'statistic',
  templateUrl: './statistic.component.html',
  styleUrls: ['./statistic.component.css']
})
export class StatisticComponent implements OnInit{
  ngOnInit(): void {
    $('#picker').pickdate();
  }
    public modulo: string = "nueve"; 
}

