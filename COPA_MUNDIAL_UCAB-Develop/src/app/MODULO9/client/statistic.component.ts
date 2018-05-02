import { Component } from '@angular/core';
import { $ } from 'protractor';


@Component({
  selector: 'statistic',
  templateUrl: './statistic.component.html',
  styleUrls: ['./statistic.component.css']
})
export class StatisticComponent {
    public modulo: string = "nueve"; 

    
    ngOninit(){
      //$('#exampleInputDatePicker1').pickdate();

      }
    
}

