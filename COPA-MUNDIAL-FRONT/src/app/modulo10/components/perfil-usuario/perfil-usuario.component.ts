import { Component, NgModule, OnInit } from '@angular/core';
import { HttpClient, HttpParams, HttpHeaders } from '@angular/common/http';
import { RouterModule, Router } from '@angular/router';
import { Usuario10 } from '../../models/usuario.model';
import { Usuario } from '../../../modulo01/models/usuario';


@Component({
  selector: 'app-perfil-usuario',
  templateUrl: './perfil-usuario.component.html',
  styleUrls: ['./perfil-usuario.component.css', '../style-usuario.component.css']
})
export class PerfilUsuarioComponent implements OnInit {
  apiRoot = 'http://192.168.15.108:54059/api/';
  usuario: Usuario10;

  constructor(private http: HttpClient) {
    this.usuario = new Usuario10();
  }
  ngOnInit() {}

  Test_Get() {
        console.log(this.usuario.Nombre);
  }
}
