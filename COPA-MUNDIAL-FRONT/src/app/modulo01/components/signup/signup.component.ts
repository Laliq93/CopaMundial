import { Component, OnInit, NgZone } from '@angular/core';
import { LoggedInGuard } from '../../../guards/logged-in.guard';
import { NotLoggedInGuard } from '../../../guards/not-logged-in.guard';
import { HttpClient, HttpParams, HttpHeaders } from '@angular/common/http';
import { FormControl, Validators } from '@angular/forms';



export interface IUsuario {
  NombreUsuario: string;
  Nombre: string;
  Apellido: string;
  FechaNacimiento: string;
  Correo: string;
  Genero: string;
  Password: string;
}

class Usuario {

  public nombreUsuario: string = '';
  public nombre: string = '';
  public apellido: string = '';
  public fechaNacimiento: string = '';
  public correo: string = '';
  public genero: string = '';
  public password: string = '';

}

@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.css']
})

export class SignupComponent implements OnInit {

  apiRoot: string = 'http://localhost:54059/api/M1_RegistroLoginRecuperar/';
  usuario: Usuario;



  constructor(private http: HttpClient, private _zone: NgZone) { 
    this.usuario = new Usuario();
  }

  ngOnInit() {
    this.RegistrarUsuario()
  }


  RegistrarUsuario() {


    let url = `${this.apiRoot}RegistrarUsuario/`+this.usuario.nombreUsuario+'/'+this.usuario.nombre;+'/'
              +this.usuario.apellido;+'/'+this.usuario.fechaNacimiento;+'/'+this.usuario.correo;+'/'
              +this.usuario.genero;+'/'+this.usuario.password;

    let httpHeaders = new HttpHeaders()
      .set('Accept', 'application/json');

    this.http.post<IUsuario>(url, { responseType: 'json' }).subscribe(data => {

      console.log(data);

    });

  }
}
