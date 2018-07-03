import { Injectable } from '@angular/core';
import {
  HttpClient,
  HttpParams,
  HttpErrorResponse
} from '@angular/common/http';
import { Router } from '@angular/router';
import { Observable, throwError } from 'rxjs';
import { catchError, retry, map } from 'rxjs/operators';

import { Equipo } from '../models/equipo';
import { Alineacion } from '../models/alineacion';
import { Estadio } from '../models/estadio';
import { Partido } from '../models/partido';
import { Jugador } from '../models/jugador';
import { config } from '../../config';

@Injectable({
  providedIn: 'root'
})
export class PartidoService {
  private API_ENDPOINT = config.url + '/';

  constructor(private _http: HttpClient, private _router: Router) {}

  public obtenerPosiciones(): Array<string> {
    return ['Portero', 'Defensa', 'Mediocampo', 'Delantero'];
  }

  public obtenerEquipos(): Observable<Array<Equipo>> {
    return this._http
    .get<Array<Equipo>>(this.API_ENDPOINT + 'equipos/obtener')
    .pipe(
      map(data => this.handleResponse(data)),
      retry(2),
      catchError(this.handleError)
    );
  }

  public obtenerEstadios(): Observable<Array<Estadio>> {
    return this._http
      .get<Array<Estadio>>(this.API_ENDPOINT + 'estadios/obtener')
      .pipe(
        map(data => this.handleResponse(data)),
        retry(2),
        catchError(this.handleError)
      );
  }

  public obtenerPartidos(): Observable<Array<Partido>> {
    return this._http
      .get<Array<Partido>>(this.API_ENDPOINT + 'partido/obtenertodos')
      .pipe(
        map(data => this.handleResponse(data)),
        retry(2),
        catchError(this.handleError)
      );
  }

  public crearPartido(partido: Partido): Observable<any> {
    return this._http
    .post(this.API_ENDPOINT + 'partido/crear', partido)
    .pipe(
      map(data => this.handleResponse(data)),
      retry(2),
      catchError(this.handleError)
    );
  }

  public actualizarPartido(partido: Partido): Observable<any> {
    return this._http
      .put(this.API_ENDPOINT + 'partido/actualizar', partido)
      .pipe(
        map(data => this.handleResponse(data)),
        retry(2),
        catchError(this.handleError)
      );
  }

  public obtenerPartidosPorFecha(fecha: Date): Observable<Array<Partido>> {
    return this._http
      .get<Array<Partido>>(this.API_ENDPOINT + 'partido/obtenerporfecha', {
                      params: { FechaInicioPartido: fecha.toLocaleString() }})
      .pipe(
        map(data => this.handleResponse(data)),
        retry(2),
        catchError(this.handleError)
      );
  }

  public obtenerPartidoPorId(id: number): Observable<Partido> {
    return this._http
      .get<Partido>(this.API_ENDPOINT + 'partido/obtener', {
                      params: { Id: id.toString() }})
      .pipe(
        map(data => this.handleResponse(data)),
        retry(2),
        catchError(this.handleError)
      );
  }

  public crearAlineacion(alineacion: Alineacion): Observable<any> {
    return this._http
      .post(this.API_ENDPOINT + 'alineacion/crear', alineacion)
      .pipe(
        map(data => this.handleResponse(data)),
        retry(2),
        catchError(this.handleError)
      );
  }

  public actualizarAlineacion(alineacion: Alineacion): Observable<any> {
    return this._http
      .put(this.API_ENDPOINT + 'alineacion/actualizar', alineacion)
      .pipe(
        map(data => this.handleResponse(data)),
        retry(2),
        catchError(this.handleError)
      );
  }

  public EliminarAlineacion(id: number): Observable<any> {
    return this._http
      .delete(this.API_ENDPOINT + 'alineacion/eliminar',
              {params: { Id: id.toString() }})
      .pipe(
        map(data => this.handleResponse(data)),
        retry(2),
        catchError(this.handleError)
      );
  }

  public obtenerJugadores(): Observable<Array<Jugador>> {
    return this._http
      .get <Array<Jugador>>(this.API_ENDPOINT + 'jugador/obtenerJugadores')
      .pipe(
        map(data => this.handleResponse(data)),
        retry(2),
        catchError(this.handleError)
      );
  }

  private handleError(error: HttpErrorResponse) {
    console.log(error);
    alert(error.error.Message);
    if (error.error instanceof ErrorEvent) {
      console.error('Ocurrio un error del lado del cliente:', error.error.message);
    } else {
      console.error(`Backend retorno error el cuerpo de la peticion fue: ${error.error}`);
    }
    return throwError('Ocurrio un error al intentar hacer la petición. Intenta de nuevo.');
  }

  private handleResponse(respuesta: any): any {
    console.log(respuesta);
    return respuesta;
  }
}
