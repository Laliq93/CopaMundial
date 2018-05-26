import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import {  Response } from "@angular/http";
import {Observable} from 'rxjs';
import 'rxjs/add/operator/map';
/*import { User } from './user.model';*/
 
@Injectable()
export class UserService {
  readonly rootUrl = 'http://localhost:4200';
  constructor(private http: HttpClient) { }
 
  registerUser(data:any){
    return this.http.post(this.rootUrl + '/api/M1_RegistroLoginRecuperar/RegistrarUsuario', data);
  }
 
}