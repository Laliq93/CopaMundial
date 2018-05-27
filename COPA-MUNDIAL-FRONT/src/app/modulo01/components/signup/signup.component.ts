import { Component, OnInit, NgZone } from '@angular/core';
import { Router } from '@angular/router';
import { LoggedInGuard } from '../../../guards/logged-in.guard';
import { NotLoggedInGuard } from '../../../guards/not-logged-in.guard';
import { HttpClient, HttpParams, HttpHeaders } from '@angular/common/http';
import { FormControl, FormBuilder, Validators, NgForm } from '@angular/forms';
import { Usuario } from '../../models/usuario';



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
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.css']
})

export class SignupComponent implements OnInit {

  usuario: Usuario;
  UsuarioForm = new Usuario();
  emailPattern = "^[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}$";
  readonly rootUrl =  'http://localhost:54059/api';

  private emailResponse;
  private truefalse:boolean = false;

  constructor(private http: HttpClient) {
    this.usuario = new Usuario();
  }

  ngOnInit() {
    //this.resetForm();
  }

  /*resetForm(form?: NgForm) {
    if (form != null)
      form.reset();
    this.usuario = {
      nombreUsuario: '',
      nombre: '',
      apellido: '',
      fechaNacimiento: '',
			correo: '',
      genero: '',
			password: ''
    }
  }*/

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
  
  /*recoveryPassword(): void {
    this.router.navigate(['recovery']);
	}*/

  
}
