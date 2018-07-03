import { Component, OnInit, NgZone, Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { LoggedInGuard } from '../../../guards/logged-in.guard';
import { NotLoggedInGuard } from '../../../guards/not-logged-in.guard';
import { HttpClient, HttpParams, HttpHeaders } from '@angular/common/http';
import { FormControl, FormBuilder, Validators, NgForm } from '@angular/forms';
import { Usuario } from '../../models/usuario';
import { DTOUsuarioRegistrar } from '../../models/dtousuario-registrar';
import { config } from '../../../config';


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

@Injectable()
export class SignupComponent implements OnInit {

  usuario: DTOUsuarioRegistrar;
  emailPattern = "^[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}$";
  readonly rootUrl =  config.url;

  private emailResponse;
  private truefalse: boolean = false;

  constructor(private router: Router, private http: HttpClient) {
    this.usuario = new DTOUsuarioRegistrar();
  }

  ngOnInit() {
    //this.resetForm();
  }

  registerUser(userRegistrationForm){
    const url = `${this.rootUrl}/Login/RegistrarUsuario`;
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
      .post<DTOUsuarioRegistrar>(url, user, httpOptions)
      .subscribe(
        success => {
          console.log(success)
          const id = success.toString();
          localStorage.setItem('userId', id);
          this.router.navigate(['/inicio','signin']);
        },
        error => alert("usuario o email en uso")
      );

  }

 /* resetForm(form?: NgForm) {
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
