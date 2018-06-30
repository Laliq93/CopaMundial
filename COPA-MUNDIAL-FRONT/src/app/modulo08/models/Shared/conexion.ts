export class Conexion {
  Controlador: string;
  IdUsuario = 1;
  Puerto = 51543;
  Ip = 'localhost';
  RutaApi = 'http://' + this.Ip + ':' + this.Puerto + '/api/';

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
