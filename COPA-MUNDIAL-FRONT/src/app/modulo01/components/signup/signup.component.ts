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



  constructor(private http: HttpClient, private _zone: NgZone) { 
    this.usuario = new Usuario();
  }

  ngOnInit() {
    this.resetForm();
  }

  resetForm(form?: NgForm) {
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
  }

  RegistrarUsuario(usuario : Usuario){
    const body: Usuario = {
      nombreUsuario : usuario.nombreUsuario,
      nombre : usuario.nombre,
      apellido : usuario.apellido,
      fechaNacimiento : usuario.fechaNacimiento,
      correo : usuario.correo,
      genero : usuario.genero,
      password : usuario.password,
    }

    return this.http.post(this.rootUrl + '/M1_RegistroLoginRecuperar/RegistrarUsuario', body);
  }

  /*recoveryPassword(): void {
    this.router.navigate(['recovery']);
	}*/
  
  OnSubmit(form : NgForm){
    this.RegistrarUsuario(form.value);
  }

  
}
