import { Component, OnInit } from '@angular/core';
declare var jquery:any;
declare var $ :any;

@Component({
  selector: 'app-predjugador',
  templateUrl: './predjugador.component.html',
  styleUrls: ['./predjugador.component.css']
})
export class PredjugadorComponent implements OnInit {

  constructor() { }

  ngOnInit() {
    $('#picker').pickdate();
  }

}
