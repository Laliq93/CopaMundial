import { Component } from '@angular/core';
import { RouterModule, Router } from '@angular/router';
import { HttpClient, HttpParams, HttpHeaders } from '@angular/common/http';

import 'rxjs/add/operator/catch';
import 'rxjs/add/operator/do';
import 'rxjs/add/operator/map';

export interface IUsuario {
  id: number;
  Nombre: string;
  Apellido: string;
  FechaNacimiento: string;
  Genero: string;
  FotoPath: string;
}

class Usuario {

  public id: number = 3;
  public nombre: string = "";
  public apellido: string = "";
  public genero: string = "";
  public fechaNacimiento: string = "";
  public fotoPath: string = "";

}


@Component({
  selector: 'user-config',
  templateUrl: './user-config.component.html',
  styleUrls: ['./user.component.css']
})



export class UserConfigComponent {

  apiRoot: string = "http://localhost:54059/api/M10_Usuario/";
  usuario: Usuario;

  constructor(private http: HttpClient) {
    this.usuario = new Usuario();
  }

  ngOnInit(): void {

    this.ObtenerDatos();
	}

  ObtenerDatos() {

    let idUsuario = this.usuario.id;

    let url = `${this.apiRoot}ObtenerUsuario/`+idUsuario.toString();
    let httpHeaders = new HttpHeaders()
      .set('Accept', 'application/json');

    //let search = new HttpParams().set('idUsuario', '2');

    this.http.get<IUsuario>(url, { responseType: 'json' }).subscribe(data => {

      this.usuario.nombre = data.Nombre;
      this.usuario.apellido = data.Apellido;
      this.usuario.genero = data.Genero;
      this.usuario.fechaNacimiento = data.FechaNacimiento;
      this.usuario.fotoPath = data.FotoPath;

      console.log(data);

    });

  }

  ActualizarDatos() {
        //ActualizarPerfil/{idUsuario:int}/{nombre}/{apellido}/{fechaNacimiento}/{genero}/{fotoPath
        
        let url = `${this.apiRoot}ActualizarPerfil/`+this.usuario.id.toString()+`/`
        +this.usuario.nombre+'/'+this.usuario.apellido+'/'+this.usuario.fechaNacimiento+'/'
        +this.usuario.genero+'/'+this.usuario.fotoPath;

        let httpHeaders = new HttpHeaders()
          .set('Accept', 'application/json');
    
        //let search = new HttpParams().set('idUsuario', '2');
    
        this.http.get<IUsuario>(url, { responseType: 'json' }).subscribe(data => {
  
          console.log(data);
    
        });
    
      }
}
