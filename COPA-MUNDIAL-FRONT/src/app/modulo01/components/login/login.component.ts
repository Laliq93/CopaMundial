import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import {Usuario} from '../../models/usuario';
import { HttpClient, HttpParams, HttpHeaders } from '@angular/common/http';
import { NgForm } from '@angular/forms';


export interface IUsuario {
  NombreUsuario: string;
  Nombre: string;
  Apellido: string;
  FechaNacimiento: string;
  Correo: string;
  Genero: string;
  Password: string;
}

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  usuario: Usuario;
  emailPattern = "^[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}$";
  readonly rootUrl =  'http://localhost:54059/api';

  private emailResponse;
  private truefalse:boolean = false;

  constructor(private http: HttpClient) {
    this.usuario = new Usuario();
  }
  ngOnInit() {
  }

  registerUser(){
    const url = `${this.rootUrl}/M1_RegistroLoginRecuperar/RegistrarUsuario`;
    const httpHeaders = new HttpHeaders().set('Accept', 'application/json');

    this.http
      .post<IUsuario>(url, { responseType: 'json' })
      .subscribe(data => {
      this.usuario.nombreUsuario = data.NombreUsuario;
      this.usuario.nombre = data.Nombre;
      this.usuario.apellido = data.Apellido;
      this.usuario.fechaNacimiento = data.FechaNacimiento;
      this.usuario.correo = data.Correo;
      this.usuario.genero = data.Genero;
      this.usuario.password = data.Password;

      console.log(data);
    });
  }


}
