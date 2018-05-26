import { Component, OnInit, NgZone } from '@angular/core';
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

/*class Usuario {

  public nombreUsuario: string = '';
  public nombre: string = '';
  public apellido: string = '';
  public fechaNacimiento: string = '';
  public correo: string = '';
  public genero: string = '';
  public password: string = '';

}*/

@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.css']
})

export class SignupComponent implements OnInit {

  usuario: Usuario;
  UsuarioForm = new Usuario();
  emailPattern = "^[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}$";
  readonly rootUrl =  'http://localhost:54059';

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

  RegisterUsuario(usuario : Usuario){
    const body: Usuario = {
      nombreUsuario : usuario.nombreUsuario,
      nombre : usuario.nombre,
      apellido : usuario.apellido,
      fechaNacimiento : usuario.fechaNacimiento,
      correo : usuario.correo,
      genero : usuario.genero,
      password : usuario.password,
    }

    return this.http.post(this.rootUrl + '/api/M1_RegistroLoginRecuperar/RegistrarUsuario', body);
  }

  /*RegistrarUsuario() {


    let url = `${this.apiRoot}RegistrarUsuario/`+this.usuario.nombreUsuario+'/'+this.usuario.nombre;+'/'
              +this.usuario.apellido;+'/'+this.usuario.fechaNacimiento;+'/'+this.usuario.correo;+'/'
              +this.usuario.genero;+'/'+this.usuario.password;

    let httpHeaders = new HttpHeaders()
      .set('Accept', 'application/json');

    this.http.post<IUsuario>(url, { responseType: 'json' }).subscribe(data => {

      console.log(data);

    });

  }*/

  OnSubmit(form : NgForm){
    this.RegisterUsuario(form.value);
  }
}
