import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-home',
  templateUrl: './homeAdmin.component.html',
  styleUrls: ['./homeAdmin.component.css']
})
export class HomeAdminComponent implements OnInit {

  today = Date.now();
  constructor() { }

  ngOnInit() {
  }

}
