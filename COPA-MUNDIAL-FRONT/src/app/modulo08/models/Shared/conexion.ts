export class Conexion {
  Controlador: string;
  IdUsuario: number = 3;
  RutaApi = 'http://192.168.15.105:51543/api/';

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
