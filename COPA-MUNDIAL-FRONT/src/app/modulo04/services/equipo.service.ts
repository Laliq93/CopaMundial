import { Injectable, OnInit } from '@angular/core';
import {
  HttpClient,
  HttpParams,
  HttpErrorResponse
} from '@angular/common/http';
import { HttpModule } from '@angular/http';
import { Equipo } from '../models/equipo';
import { Pais } from '../models/pais';
import { I18nEquipo } from '../models/i18n_equipo';
import { RespuestaApi } from '../models/respuestaApi';
import { Observable, throwError } from 'rxjs';
import { catchError, retry, map } from 'rxjs/operators';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class EquipoService {
  API_ENDPOINT = 'https://f730ed04-2345-4437-a430-f8dabfa7e5be.mock.pstmn.io/api/M4_GestionEquipo/';

  constructor(private _http: HttpClient, private _router: Router) {}

  public obtenerGrupos() {
    return ['A', 'B', 'C', 'D', 'E', 'F', 'G', 'H'];
  }

  public obtenerEquipos(): Observable<Equipo[]> {
    return this._http
      .get<RespuestaApi<Equipo[]>>(this.API_ENDPOINT)
      .pipe(
        map(data => this.crearUrlBanderasParaEquipos(this.handleResponse(data))),
        retry(2),
        catchError(this.handleError)
      );
  }

  public obtenerEquipo(equipo: string): Observable<Equipo> {
    // const params = new HttpParams().set('equipo', equipo);
    return this._http
      .get<RespuestaApi<Equipo>>(this.API_ENDPOINT + 'obtenerUno')
      .pipe(
        map(data => this.crearUrlBanderaParaEquipo(this.handleResponse(data))),
        retry(2),
        catchError(this.handleError)
      );
  }

  public editarEquipo(equipo: Equipo): Observable<Equipo> {
    return this._http
      .put<RespuestaApi<Equipo>>(this.API_ENDPOINT + 'actualizar', equipo)
      .pipe(
        map(data => this.handleResponse(data)),
        retry(2),
        catchError(this.handleError)
      );
  }

  public crearEquipo(equipo: Equipo): Observable<Equipo> {
    return this._http
      .post<RespuestaApi<Equipo>>(this.API_ENDPOINT + 'crear', equipo)
      .pipe(
        map(data => this.handleResponse(data)),
        retry(2),
        catchError(this.handleError)
      );
  }

  public obtenerPaises(): Observable<Pais[]> {
    return this._http
      .get<RespuestaApi<Pais[]>>(this.API_ENDPOINT + 'pais')
      .pipe(
        map(data => this.crearUrlBanderas(this.handleResponse(data))),
        retry(2),
        catchError(this.handleError)
      );
  }

  private handleError(error: HttpErrorResponse) {
    if (error.error instanceof ErrorEvent) {
      console.error(
        'Ocurrio un error del lado del cliente:',
        error.error.message
      );
    } else {
      console.error(
        `Backend retorno el codigo ${error.error.message.code}, ` +
          `el cuerpo de la peticion fue: ${error.error}`
      );
    }
    return throwError(
      'Ocurrio un error al intentar hacer la petición. Intenta de nuevo.'
    );
  }

  private handleResponse(respuesta: RespuestaApi<any>): any {
    console.log(respuesta);
    if (respuesta.codigo !== 200) {
      console.error('Ocurrio un error: ' + respuesta.error);

      return throwError(
        'Ocurrio un error al intentar hacer la petición. Intenta de nuevo.'
      );
    } else {
      return respuesta.mensaje;
    }
  }

  private crearUrlBandera(pais: Pais): Pais {
    pais.urlBandera = this._router.serializeUrl(
      this._router.createUrlTree([
        '/assets',
        'banderas',
        pais.iso.toLowerCase() + '.png'
      ])
    );
    return pais;
  }

  private crearUrlBanderaParaEquipo(equipo: Equipo): Equipo {
    equipo.pais = this.crearUrlBandera(equipo.pais);

    return equipo;
  }

  private crearUrlBanderasParaEquipos(equipos: Equipo[]): Equipo[] {
    equipos.forEach(equipo => {
      equipo.pais = this.crearUrlBandera(equipo.pais);
    });
    return equipos;
  }

  private crearUrlBanderas(paises: Pais[]): Pais[] {
    paises.forEach(pais => {
      pais = this.crearUrlBandera(pais);
    });
    return paises;
  }
}
