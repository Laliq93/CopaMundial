import { config } from '../../config';

export class Conexion {
    controller: string;
    root = config.url;
  
    public GetApiJugador() {
      return this.root + '/Jugador/';
    }
  }