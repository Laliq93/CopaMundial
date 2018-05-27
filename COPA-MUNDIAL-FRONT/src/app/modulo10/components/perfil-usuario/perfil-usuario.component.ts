import { Component, NgModule, OnInit } from '@angular/core';
import { HttpClient, HttpParams, HttpHeaders } from '@angular/common/http';
import { RouterModule, Router } from '@angular/router';
import { Usuario10, IUsuario10, Conexion } from '../../models/usuario.model';
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
  usuario: Usuario10;
  conexion: Conexion;
  // login: Usuario;

  constructor(private http: HttpClient) {
    this.usuario = new Usuario10();
    this.conexion = new Conexion();
    //this.login = new Usuario();
    this.usuario.Id = 2;
  }
  ngOnInit() {
    this.ObtenerDatos();
  }

  ObtenerDatos() {
    this.conexion.Controlador = 'ObtenerUsuario/';

    const url =
      this.conexion.RutaApi + this.conexion.Controlador + this.usuario.Id;
    const httpHeaders = new HttpHeaders().set('Accept', 'application/json');

    // let search = new HttpParams().set('idUsuario', '2');

    this.http.get<IUsuario10>(url, { responseType: 'json' }).subscribe(data => {
      this.usuario.Nombre = data.Nombre;
      this.usuario.Apellido = data.Apellido;
      this.usuario.Correo = data.Correo;
      this.usuario.FechaNacimiento = data.FechaNacimiento;
      if (data.Message == null) {
        console.log('funciona');
      } else {
        console.log(data.Message);
      }
    });
  }

  Test_Get() {
    console.log(this.usuario.FechaNacimiento);
  }
}
