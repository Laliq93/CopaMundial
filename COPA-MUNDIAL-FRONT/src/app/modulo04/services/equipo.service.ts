import { Injectable, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { HttpModule } from '@angular/http';

@Injectable({
  providedIn: 'root'
})
export class EquipoService {

  API_ENDPOINT = 'http://localhost:54059/api/M4_GestionEquipo/';

  constructor(private http: HttpClient) { }

  getGrupos(){
    return ['A', 'B', 'C', 'D', 'E', 'F', 'G', 'H'];
  }

  // esto es de prueba
  getConfig() {
    return this.http.get('http://localhost:54059/api/M4_GestionEquipo/prueba');
  }

}
