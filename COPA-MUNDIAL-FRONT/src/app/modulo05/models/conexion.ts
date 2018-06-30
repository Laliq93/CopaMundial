export class Conexion {
    controller: string;
    root = 'http://localhost:51543/api/';
  
    public GetApiJugador() {
      return this.root + 'Jugador/';
    }
  }