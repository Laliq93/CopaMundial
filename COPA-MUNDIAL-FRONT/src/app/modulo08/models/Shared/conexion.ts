export class Conexion {
  Controlador: string;
  RutaApi = 'http://192.168.15.111:51543/api/';

  public GetApiJugador() {
    return this.RutaApi + 'Jugador/';
  }

  public GetApiApuesta() {
    return this.RutaApi + 'Apuesta/';
  }
}
