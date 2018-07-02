import { Partido } from '../models/partido';
import { Equipo } from '../models/equipo';
import { Jugador } from '../models/jugador';

export class Alineacion {
    Id: number;
    EsCapitan: boolean;
    Posicion: string;
    EsTitular: boolean;
    Jugador: Jugador | number;
    Equipo: Equipo | number;
    Partido: Partido | number;
  }
