import { Injectable, OnInit, Inject, LOCALE_ID } from '@angular/core';
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
  private API_ENDPOINT = 'http://localhost:54072/api/M4_GestionEquipo/';
  public idioma: string;

  constructor(
    private _http: HttpClient,
    private _router: Router,
    @Inject(LOCALE_ID) locale: string
  ) {
    this.idioma = locale.split('-')[0];
  }

  public obtenerGrupos() {
    return ['A', 'B', 'C', 'D', 'E', 'F', 'G', 'H'];
  }

  public obtenerEquipos(): Observable<Equipo[]> {
    return this._http
      .get<RespuestaApi<Equipo[]>>(
        this.API_ENDPOINT + 'listaEquipos/' + this.idioma
      )
      .pipe(
        map(data =>
          this.crearUrlBanderasParaEquipos(this.handleResponse(data))
        ),
        retry(2),
        catchError(this.handleError)
      );
  }

  public obtenerEquipo(equipo: string): Observable<Equipo> {
    return this._http
      .get<RespuestaApi<Equipo>>(this.API_ENDPOINT + 'equipo/' + equipo)
      .pipe(
        map(data => this.crearUrlBanderaParaEquipo(this.handleResponse(data))),
        retry(2),
        catchError(this.handleError)
      );
  }

  public editarEquipo(equipo: Equipo): Observable<Equipo> {
    return this._http
      .put<RespuestaApi<Equipo>>(this.API_ENDPOINT + 'ActualizarEquipo', equipo)
      .pipe(
        map(data => this.handleResponse(data)),
        retry(2),
        catchError(this.handleError)
      );
  }

  public crearEquipo(equipo: Equipo): Observable<Equipo> {
    return this._http
      .post<RespuestaApi<Equipo>>(this.API_ENDPOINT + 'AgregarEquipo', equipo)
      .pipe(
        map(data => this.handleResponse(data)),
        retry(2),
        catchError(this.handleError)
      );
  }

  public obtenerPaises(): Observable<Pais[]> {
    return this._http
      .get<RespuestaApi<Pais[]>>(
        this.API_ENDPOINT + 'ObtenerPaises/' + this.idioma
      )
      .pipe(
        map(data => this.crearUrlBanderas(this.handleResponse(data))),
        retry(2),
        catchError(this.handleError)
      );
  }

  private handleError(error: HttpErrorResponse) {
    console.log(error);
    if (error.error instanceof ErrorEvent) {
      console.error(
        'Ocurrio un error del lado del cliente:',
        error.error.message
      );
    } else {
      console.error(
        `Backend retorno error` +
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
