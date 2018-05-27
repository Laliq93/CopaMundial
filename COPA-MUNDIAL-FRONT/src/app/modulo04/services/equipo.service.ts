import { Injectable, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { HttpModule } from '@angular/http';
import { Equipo } from '../models/equipo';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class EquipoService {

  API_ENDPOINT = 'http://localhost:54059/api/M4_GestionEquipo/';

  constructor(private http: HttpClient) { }

  getGrupos() {
    return ['A', 'B', 'C', 'D', 'E', 'F', 'G', 'H'];
  }

  // esto es de prueba
  getConfig() {
    return this.http.get('http://localhost:54059/api/M4_GestionEquipo/prueba');
  }

  /** PUT: Actualiza el equipo en el webApi. Returna el equipo actualizado en caso de exito. */
  editarEquipo (equipo: Equipo): Observable<Equipo> {
    return this.http.put<Equipo>('http://localhost:54059/api/M4_GestionEquipo/prueba', equipo);
  }

}
