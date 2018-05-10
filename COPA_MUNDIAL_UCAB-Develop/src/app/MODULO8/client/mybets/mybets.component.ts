import { Component, OnInit } from '@angular/core';
import {RouterModule, Router } from '@angular/router';

@Component({
  selector: 'app-mybets',
  templateUrl: './mybets.component.html',
  styleUrls: ['./mybets.component.css']
})
export class MybetsComponent implements OnInit {

  constructor(private router: Router){}
  goJuegos() {
    this.router.navigate(['home/bet']); 
  }
 
  ngOnInit() {
  }
}
