import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import {  Response } from "@angular/http";
import {Observable} from 'rxjs';
import 'rxjs/add/operator/map';
import { User } from './user.model';
 
@Injectable()
export class UserService {
  readonly rootUrl = 'http://localhost:35257';
  constructor(private http: HttpClient) { }
 
  registerUser(user : User){
    const body: User = {
      Usuario: user.Usuario,
      Nombre: user.Nombre,
	  Apellido: user.Apellido,
	  FechaNac: user.FechaNac,
      Correo: user.Correo,
      Contrasena: user.Contrasena
    }
    return this.http.post(this.rootUrl + '/api/User/Register', body);
  }
 
}