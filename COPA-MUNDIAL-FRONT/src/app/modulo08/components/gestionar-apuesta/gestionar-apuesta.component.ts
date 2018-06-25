import { Component, OnInit } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { Subject } from "rxjs";

declare var bootbox: any;

@Component({
  selector: 'app-gestionar-apuesta',
  templateUrl: './gestionar-apuesta.component.html',
  styleUrls: [
    './gestionar-apuesta.component.css',
    '../shared/style-apuesta.component.css'
  ]
})

export class GestionarApuestaComponent implements OnInit {
  constructor() {}

  ngOnInit() {}
}
