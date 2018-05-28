import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-datos-torneo',
  templateUrl: './datos-torneo.component.html',
  styleUrls: ['./datos-torneo.component.css']
})
export class DatosTorneoComponent implements OnInit {

  constructor(private router: Router){}

  ngOnInit() {
  }

}
