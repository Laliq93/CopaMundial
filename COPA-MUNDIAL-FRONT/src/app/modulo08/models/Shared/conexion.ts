export class Conexion {
  Controlador: string;
  IdUsuario = 4;
  Puerto = 51543;
  Ip = '192.168.15.105';
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
