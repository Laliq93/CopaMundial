export class Jugador {
  id: number;
  nombre: string;
  apellido: string;
  fecha_nac: Date;
  lugar_nac: string;
  peso: number;
  altura: number;
  numero: number;
  posicion: string;
  capitan: boolean;
  club?: string;
  equipo?: string;

  constructor(data?) {
    if (data) {
      this.id = data.id;
      this.nombre = data.nombre;
      this.apellido = data.apellido;
      this.fecha_nac = data.fecha_nac;
      this.lugar_nac = data.lugar_nac;
      this.peso = data.peso;
      this.altura = data.altura;
      this.numero = data.numero;
      this.posicion = data.posicion;
      this.capitan = data.capitan;
      if (data.club) {
        this.club = data.club;
      }
      if (data.equipo) {
        this.equipo = data.equipo;
      }
    }
  }

}
