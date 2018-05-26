import { Component, NgModule, OnInit } from '@angular/core';
import { HttpClient, HttpParams, HttpHeaders } from '@angular/common/http';
import { BrowserModule } from '@angular/platform-browser';
import { platformBrowserDynamic } from '@angular/platform-browser-dynamic';
import { RouterModule, Router } from '@angular/router';

import 'rxjs/add/operator/catch';
import 'rxjs/add/operator/do';
import 'rxjs/add/operator/map';

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
  styleUrls: ['./perfil-usuario.component.css']
})
export class PerfilUsuarioComponent implements OnInit {
  apiRoot = 'http://localhost:54059/api/';
  usuario: Usuario;

  constructor(private http: HttpClient) {
    this.usuario = new Usuario();
  }
  ngOnInit() {}

  Test_Get() {
    let url = `${this.apiRoot}/M10_Usuario/ObtenerUsuario/`;
    let httpHeaders = new HttpHeaders().set('Accept', 'application/json');

    let search = new HttpParams().set('idUsuario', '2');

    this.http
      .get<IUsuario>(url, { params: search, responseType: 'json' })
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
