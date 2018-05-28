import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class ServicioService {

  API = 'http://localhost:54059/api/M09_estadisticas/jugador/'
  constructor() { }

  getEstadisticas(){
    
  }
}
