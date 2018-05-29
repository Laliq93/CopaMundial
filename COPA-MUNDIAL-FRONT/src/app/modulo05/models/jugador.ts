export class Jugador {
  Id: number;
  Nombre: string;
  Apellido: string;
  FechaNacimiento: string;
  LugarNacimiento: string;
  Peso: number;
  Altura: number;
  Numero: number;
  Posicion: string;
  Capitan: boolean;
  Club: string;
  Equipo?: number;

  constructor(data?) {
    if (data) {
      this.Id = data.id;
      this.Nombre = data.nombre;
      this.Apellido = data.apellido;
      this.FechaNacimiento = data.fecha_nac;
      this.LugarNacimiento = data.lugar_nac;
      this.Peso = data.peso;
      this.Altura = data.altura;
      this.Numero = data.numero;
      this.Posicion = data.posicion;
      this.Capitan = data.capitan;
      this.Club = data.club;
      if (data.equipo) {
        this.Equipo = data.equipo;
      }
    }
  }

}
