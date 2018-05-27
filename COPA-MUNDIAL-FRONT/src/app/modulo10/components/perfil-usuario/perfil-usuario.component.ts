import { Component, NgModule, OnInit } from '@angular/core';
import { RouterModule, Router } from '@angular/router';
import { Usuario10 } from '../../models/usuario.model';
import { ApiService } from '../../services/api10.services';
import { HttpClient } from '@angular/common/http';
// import { Usuario } from '../../../modulo01/models/usuario';

@Component({
  selector: 'app-perfil-usuario',
  templateUrl: './perfil-usuario.component.html',
  styleUrls: [
    './perfil-usuario.component.css',
    '../style-usuario.component.css'
  ]
})
export class PerfilUsuarioComponent implements OnInit {
  private _usuario: Usuario10;
  private _api10: ApiService;

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

  TestEditarPerfil() {
    let errorCode: string;

    this._usuario.Nombre = 'Wilmer';
    this._usuario.Apellido = 'Pendejo';
    this._usuario.FechaNacimiento = '10-10-1995';
    this._usuario.FotoPath = 'C://';
    this._usuario.Genero = 'M';

    errorCode = this._api10.EditarPerfil(this._usuario);

    console.log(errorCode);
  }

  TestActualizarCorreo(){

    this._usuario.Password = 'pepe';
    this._usuario.Correo = 'felixd123@hotmail.com';

    this._api10.ActualizarCorreo(this._usuario);
  }

  TestActualizarClave(){

    let passwordNueva = 'pepe';
    
    this._usuario.Password = 'lol123';
    
    this._api10.ActualizarClave(this._usuario, passwordNueva);
  }

  TestDesactivarCuentaPropia(){

    this._usuario.Password = 'pepe';

    if(!this._usuario.Activo){
        alert('La cuenta ya está desactivada');
        return;
    }

    this._api10.DesactivarCuentaPropia(this._usuario);

    this._usuario = this._api10.ObtenerDatos();
  }

  TestActivar(){

    if(this._usuario.Activo){
      
      alert('La cuenta ya está activa');
      return;
    
    }
    
    this._api10.ActivarCuenta(this._usuario);

    this._usuario = this._api10.ObtenerDatos();
  }
}
