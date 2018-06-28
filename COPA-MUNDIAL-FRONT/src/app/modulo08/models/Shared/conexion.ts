export class Conexion {
  Controlador: string;
  RutaApi = 'http://192.168.15.100:51543/api/';

  public GetApiJugador() {
    return this.RutaApi + 'Jugador/';
  }

  public GetApiApuesta() {
    return this.RutaApi + 'Apuesta/';
  }

  public GetApiLogro(){
    return this.RutaApi + 'Logros/';
  }
}
