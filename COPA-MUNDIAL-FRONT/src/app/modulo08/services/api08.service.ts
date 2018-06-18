import { Injectable } from '@angular/core';
import { Apuesta, Conexion } from '../models/apuesta.model';
import { RouterModule, Router } from '@angular/router';
import {
  HttpClient,
  HttpParams,
  HttpHeaders,
  HttpErrorResponse
} from '@angular/common/http';
import { Usuario } from '../../modulo01/models/usuario';
import { Location } from '@angular/common';

declare var bootbox, router: any;

@Injectable({
  providedIn: 'root'
})
export class Api08Service {
  private _conexion: Conexion;
  private _apuesta: Apuesta;

  constructor(private http: HttpClient) {
    this._conexion = new Conexion();
    this._apuesta = new Apuesta();
  }
}
