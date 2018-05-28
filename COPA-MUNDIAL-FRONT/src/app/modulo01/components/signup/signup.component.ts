import { Component, OnInit, NgZone } from '@angular/core';
import { Router } from '@angular/router';
import { LoggedInGuard } from '../../../guards/logged-in.guard';
import { NotLoggedInGuard } from '../../../guards/not-logged-in.guard';
import { HttpClient, HttpParams, HttpHeaders } from '@angular/common/http';
import { FormControl, FormBuilder, Validators, NgForm } from '@angular/forms';
import { Usuario } from '../../models/usuario';


const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type':  'application/json'
  })
};

@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.css']
})

export class SignupComponent implements OnInit {

  usuario: Usuario;
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

  registerUser(userRegistrationForm){
    const url = `${this.rootUrl}/M1_RegistroLoginRecuperar/RegistrarUsuario`;
    const httpHeaders = new HttpHeaders().set('Accept', 'application/json');


    const {NombreUsuario, Nombre, Apellido, FechaNacimiento, Correo, Genero, Password} = userRegistrationForm.controls;
    

    console.log(userRegistrationForm.controls, Nombre.value, Apellido.value);
    
    
    const user = {
      nombreUsuario   : NombreUsuario.value,
      nombre          : Nombre.value,
      apellido        : Apellido.value,
      fechaNacimiento : FechaNacimiento.value,
      correo          : Correo.value,
      genero          : Genero.value,
      password        : Password.value  
    };

      this.http
      .post<Usuario>(url, user, httpOptions)
      .subscribe(data => {


      
      /*this.usuario.nombreUsuario = data.NombreUsuario;
      this.usuario.nombre = data.Nombre;
      this.usuario.apellido = data.Apellido;
      this.usuario.fechaNacimiento = data.FechaNacimiento;
      this.usuario.correo = data.Correo;
      this.usuario.genero = data.Genero;
      this.usuario.password = data.Password;*/

      console.log(data);
    });
    
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
  
}
