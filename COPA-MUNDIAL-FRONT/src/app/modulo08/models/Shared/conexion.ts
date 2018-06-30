export class Conexion {
  Controlador: string;
  IdUsuario: number = 4;
  RutaApi = 'http://localhost:51543/api/';

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
