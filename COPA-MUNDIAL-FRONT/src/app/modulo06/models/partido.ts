import { Alineacion } from '../models/alineacion';
import { Equipo } from '../models/equipo';
import { Estadio } from '../models/estadio';

export class Partido {
    Id: number;
    FechaInicioPartido: Date;
    FechaFinPartido: Date;
    Arbitro: string;
    Equipo1: Equipo | number;
    Equipo2: Equipo | number;
    Estadio: Estadio | number;
    Alineaciones: Array<Alineacion>;
    bandera1: String;
    bandera2: String;

    CargarPartido(id: number, fechaInicio: Date, fechaFin: Date,
                  arbitro: string, equipo1: Equipo, equipo2: Equipo, estadio: Estadio) {
      this.Id = id;
      this.FechaInicioPartido = fechaInicio;
      this.FechaFinPartido = fechaFin;
      this.Arbitro = arbitro;
      this.Equipo1 = equipo1;
      this.Equipo2 = equipo2;
      this.Estadio = estadio;
    }

    CargarPartidoPlano(id: number, fechaInicio: Date, fechaFin: Date,
                       arbitro: string, equipo1: number, equipo2: number, estadio: number) {
      this.Id = id;
      this.FechaInicioPartido = fechaInicio;
      this.FechaFinPartido = fechaFin;
      this.Arbitro = arbitro;

      this.Equipo1 = new Equipo();
      this.Equipo1.Id = equipo1;

      this.Equipo2 = new Equipo();
      this.Equipo2.Id = equipo2;

      this.Estadio = new Estadio();
      this.Estadio.Id = estadio;
    }

    CargarPartidoSoloId(id: number) {
      this.Id = id;
    }

    CargarPartidoSoloFechaInicio(fechaInicio: Date) {
      this.FechaInicioPartido = fechaInicio;
    }
  }
