import { Injectable } from '@angular/core';
import {
   DTOMostrarPartido,
   DTOMostrarLogros,
   DTOEnviarIdPartido,
   Conexion } from '../models/index';

import {
  HttpClient
} from '@angular/common/http';

declare var bootbox, router: any;

@Injectable({
  providedIn: 'root'
})
export class Api08Service {

  private _conexion: Conexion;
  private _DTOMostrarPartido: DTOMostrarPartido;
  private _DTOEnviarPartido: DTOEnviarIdPartido;
  private _DTOMostrarLogros: DTOMostrarLogros;

  constructor(private http: HttpClient) {
    this._conexion = new Conexion();
    this._DTOMostrarPartido = new DTOMostrarPartido();
  }
}
