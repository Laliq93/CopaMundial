import { Directive, HostListener } from '@angular/core';
import * as $ from 'jquery';

@Directive({
  selector: '[appContarClicks]'
})
export class ContarClicksDirective {

  constructor() { }

  

  @HostListener('click',['$event.target']) 
  onclick(btn){
    //console.log('click',btn,"Numero de clicks:", this.clicks++);
    $('#picker').pickdate();
  }

}
