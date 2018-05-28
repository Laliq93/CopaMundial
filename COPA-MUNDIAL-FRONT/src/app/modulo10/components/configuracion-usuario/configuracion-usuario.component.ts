import { Component, OnInit, NgZone, AfterViewInit } from '@angular/core';
import { RouterModule, Router } from '@angular/router';
import { Usuario10 } from '../../models/usuario.model';
import { ApiService } from '../../services/api10.services';
import { HttpClient } from '@angular/common/http';

declare var bootbox: any;

@Component({
  selector: 'app-configuracion-usuario',
  templateUrl: './configuracion-usuario.component.html',
  styleUrls: [
    './configuracion-usuario.component.css',
    '../style-usuario.component.css'
  ]
})
export class ConfiguracionUsuarioComponent implements OnInit, AfterViewInit {
  public _usuario: Usuario10;
  public _api10: ApiService;

  public _nombreNew;
  public _apellidoNew;
  public _generoNew;
  public _fechaNew;
  public _FotoNew;

  constructor(private http: HttpClient) {
    this._api10 = new ApiService(http);
    this._usuario = new Usuario10();
    this._usuario = this._api10.ObtenerDatos();
  }

  ngOnInit() {

  }

  ngAfterViewInit(): void {
  }

  ActualizarPerfil() {
    
    if (this._nombreNew != null) {
      this._usuario.Nombre = this._nombreNew;
    }

    if (this._apellidoNew != null) {
      this._usuario.Apellido = this._apellidoNew;
    }
    
    if(this._fechaNew != null)
      this._usuario.FechaNacimiento = this._fechaNew;

    this._api10.EditarPerfil(this._usuario);
  }
}
