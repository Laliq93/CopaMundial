import { Component, OnInit } from '@angular/core';
import {
  Conexion
} from '../../models/index';
import { Api08Service } from '../../services/api08.service';
import { HttpClient } from '@angular/common/http';

declare var bootbox: any;

@Component({
  selector: 'app-admin-apuesta',
  templateUrl: './admin-apuesta.component.html',
  styleUrls: [
    './admin-apuesta.component.css',
    '../shared/style-apuesta.component.css'
  ]
})
export class AdminApuestaComponent implements OnInit {

  public api08: Api08Service;
  public connect: Conexion;

  constructor(private http: HttpClient) {
    this.api08 = new Api08Service(http);
    this.connect = new Conexion();
  }

  ngOnInit() {}
}
