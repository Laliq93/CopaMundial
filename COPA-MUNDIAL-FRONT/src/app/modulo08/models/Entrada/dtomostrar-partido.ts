export class DTOMostrarPartido {

  private _id: number = null;
  private _equipo1: string;
  private _equipo2: String;
  private _fechaPartido: string;

  get Id() {
    return this._id;
  }

  set Id(value) {
    this._id = value;
  }

  get Equipo1() {
    return this._equipo1;
  }

  set Equipo1(value) {
    this._equipo1 = value;
  }

  get Equipo2() {
    return this._equipo2;
  }

  set Equipo2(value) {
    this._equipo2 = value;
  }

  get FechaPartido() {
    return this._fechaPartido;
  }

  set FechaPartido(value) {
    this._fechaPartido = value;
  }
}
