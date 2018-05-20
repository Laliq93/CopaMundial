import { Component, NgModule } from '@angular/core';
import { HttpClient, HttpParams, HttpHeaders } from '@angular/common/http';
//import { URLSearchParams, RequestOptions } from '@angular/http';
import { BrowserModule } from '@angular/platform-browser';
import { platformBrowserDynamic } from '@angular/platform-browser-dynamic';
import { Observable } from 'rxjs/observable'

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

  public nombre: string = "";
  public apellido: string = "";
  public correo: string = "";
  public fechaNacimiento: string = "";

}
@Component({
  selector: 'user-panel',
  templateUrl: './user-panel.component.html',
  styleUrls: ['./user.component.css']
})

export class UserPanelComponent {

  apiRoot: string = "http://localhost:54059/api/";
  usuario: Usuario;

  constructor(private http: HttpClient) {
    this.usuario = new Usuario();
  }
  Test_Get() {

    let url = `${this.apiRoot}/M10_Usuario/ObtenerUsuario/`;
    let httpHeaders = new HttpHeaders()
      .set('Accept', 'application/json');

    let search = new HttpParams().set('idUsuario', '2');

    this.http.get<IUsuario>(url, { params: search, responseType: 'json' }).subscribe(data => {

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