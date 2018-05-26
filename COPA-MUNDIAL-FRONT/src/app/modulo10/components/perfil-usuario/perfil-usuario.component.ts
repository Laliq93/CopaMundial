import { Component, NgModule, OnInit } from '@angular/core';
import { HttpClient, HttpParams, HttpHeaders } from '@angular/common/http';
import { RouterModule, Router } from '@angular/router';

export interface IUsuario {
  id: number;
  Nombre: string;
  Apellido: string;
  FechaNacimiento: string;
  Correo: string;
}

class Usuario {
  public nombre = '';
  public apellido = '';
  public correo = '';
  public fechaNacimiento = '';
}

@Component({
  selector: 'app-perfil-usuario',
  templateUrl: './perfil-usuario.component.html',
  styleUrls: ['./perfil-usuario.component.css', '../style-usuario.component.css']
})
export class PerfilUsuarioComponent implements OnInit {
  apiRoot = 'http://192.168.15.108:54059/api/';
  usuario: Usuario;

  constructor(private http: HttpClient) {
    this.usuario = new Usuario();
  }
  ngOnInit() {}

  Test_Get() {
    const url = `${this.apiRoot}/M10_Usuario/ObtenerUsuario/2`;
    const httpHeaders = new HttpHeaders().set('Accept', 'application/json');

    this.http
      .get<IUsuario>(url, { responseType: 'json' })
      .subscribe(data => {
        this.usuario.nombre = data.Nombre;
        this.usuario.apellido = data.Apellido;
        this.usuario.correo = data.Correo;
        this.usuario.fechaNacimiento = data.FechaNacimiento;

        console.log(data);
      });

    /*this.http.get(url,{search}).map(res => { return res.json()}) << usando HttpModule y Http
      .subscribe(data => { 
        this.nombre = data.nombre;
        this.apellido = data.apellido;
        this.correo = data.correo;
        this.fechaNacimiento = data.fechaNacimiento;
    });*/
  }
}
