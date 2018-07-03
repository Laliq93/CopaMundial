import { config } from '../../../config';

export class Conexion {
  Controlador: string;
  IdUsuario = 1;
  Puerto = config.puerto;
  Ip = config.ip;
  RutaApi = config.url;

  public GetApiJugador() {
    return this.RutaApi + 'Jugador/';
  }

  public GetApiApuesta() {
    return this.RutaApi + 'Apuesta/';
  }

  public GetApiLogro() {
    return this.RutaApi + 'Logros/';
  }
}
