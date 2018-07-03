import { Component, NgModule, OnInit } from '@angular/core';
import { RouterModule, Router } from '@angular/router';
import { Usuario10 } from '../../models/usuario.model';
import { ApiService } from '../../services/api10.services';
import { HttpClient } from '@angular/common/http';
// import { Usuario } from '../../../modulo01/models/usuario';

declare var bootbox: any;

@Component({
  selector: 'app-perfil-usuario',
  templateUrl: './perfil-usuario.component.html',
  styleUrls: [
    './perfil-usuario.component.css',
    '../style-usuario.component.css'
  ]
})
export class PerfilUsuarioComponent implements OnInit {
  public _usuario: Usuario10;
  public _api10: ApiService;

  constructor(private http: HttpClient) {
    this._api10 = new ApiService(http);
    this._usuario = new Usuario10();
  }

  ngOnInit() {
    this.ObtenerDatos();
  }

  ObtenerDatos() {
    this._usuario = this._api10.ObtenerDatos();
  }

}
