import { Equipo } from '../models/equipo';

export class Jugador {
    Id: number;
    Nombre: string;
    Apellido: string;
    FechaNacimiento: string;
    LugarNacimiento: string;
    Peso: number;
    Altura: number;
    Posicion: string;
    Numero: number;
    Equipo: Equipo;
}