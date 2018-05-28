import { Injectable } from '@angular/core';

import { Observable, of } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { catchError, map, tap } from 'rxjs/operators';

import { Jugador } from '../models/jugador';

const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};

@Injectable({
  providedIn: 'root'
})
export class JugadorService {
  jugadoresUrl = 'http://localhost:63088/api/jugadores';

  constructor(
    private http: HttpClient
  ) { }

  getJugadores(): Observable<Jugador[]> {
    // return of(JUGADORES);
    return this.http.get<Jugador[]>(this.jugadoresUrl).pipe(
      catchError(this.handleError('getHeroes', []))
    );
  }

  getJugador(id: number): Observable<Jugador> {
    // return of(JUGADORES.find(jugador => jugador.id === id));
    const url = `${this.jugadoresUrl}/${id}`;
    return this.http.get<Jugador>(url).pipe(
      tap(_ => this.log(`fetched jugador id=${id}`)),
      catchError(this.handleError<Jugador>(`getJugador id=${id}`))
    );
  }

  updateJugador(jugador: Jugador): Observable<any> {

    return this.http.put(this.jugadoresUrl, jugador, httpOptions).pipe(
      tap(_ => this.log(`updated jugador id=${jugador.id}`)),
      catchError(this.handleError<any>('updateHero'))
    );
  }

  addJugador(jugador: Jugador): Observable<Jugador> {
    return this.http.post<Jugador>(this.jugadoresUrl, jugador, httpOptions).pipe(
      tap(_ => this.log(`added jugador w/ id=${jugador.id}`)),
      catchError(this.handleError<Jugador>('addJugador'))
    );
  }

  searchJugador(equipo: string): Observable<Jugador[]> {
    if (!equipo.trim()) {
      // if not search term, return empty hero array.
      return this.getJugadores();
    }
    return this.http.get<Jugador[]>(`${this.jugadoresUrl}/eq/${equipo}`).pipe(
      tap(_ => this.log(`found jugadores matching "${equipo}"`)),
      catchError(this.handleError<Jugador[]>('searchHeroes', []))
    );
  }

  /**
 * Handle Http operation that failed.
 * Let the app continue.
 * @param operation - name of the operation that failed
 * @param result - optional value to return as the observable result
 */
  private handleError<T>(operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {

      // TODO: send the error to remote logging infrastructure
      console.error(error); // log to console instead

      // TODO: better job of transforming error for user consumption
      this.log(`${operation} failed: ${error.message}`);

      // Let the app keep running by returning an empty result.
      return of(result as T);
    };
  }

  /** Log a HeroService message with the MessageService */
  private log(message: string) {
    // this.messageService.add('HeroService: ' + message);
    console.log(message);
  }
}
