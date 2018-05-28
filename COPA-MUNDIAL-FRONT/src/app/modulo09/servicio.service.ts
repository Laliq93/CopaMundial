import { Injectable } from "@angular/core";

@Injectable({
  providedIn: 'root'
})
export class ServicioService {

  API = 'http://localhost:54059/api/M09_estadisticas/jugador/'
  constructor() { }

  getEstadisticas(){
    
  }


}

interface estadisticasJugador{
  gol : number;
  asistencias : number;
  tiempojugado : number;
  tiros : number;
  tarjetasR : number;
  tarjetasA : number;
  faltasR : number;
  faltasC : number;
  golesrec : number;
  penaltisA : number;
  portimb : number;
  offsides : number;
  
}