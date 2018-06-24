import { Injectable } from '@angular/core';
import { DTOMostrarPartido, Conexion } from '../models/index';
import {
  HttpClient,
  HttpParams,
  HttpHeaders,
  HttpErrorResponse
} from '@angular/common/http';

declare var bootbox, router: any;

@Injectable({
  providedIn: 'root'
})
export class Api08Service {
  private _conexion: Conexion;
  private _DTOMostrarPartido: DTOMostrarPartido;

  constructor(private http: HttpClient) {
    this._conexion = new Conexion();
    this._DTOMostrarPartido = new DTOMostrarPartido();
  }
}
