import { Injectable } from '@angular/core';
import {
  Conexion,
  DTOApuestaVOF,
  DTOApuestaCantidad,
  DTOApuestaEquipo,
  DTOApuestaJugador
} from '../models/index';
import { HttpClient } from '@angular/common/http';

declare var bootbox;

@Injectable({
  providedIn: 'root'
})
export class Api08Service {
  public api08: Api08Service;
  public connect: Conexion;

  public ApuestaVof: DTOApuestaVOF;
  public ApuestaCantidad: DTOApuestaCantidad;
  public ApuestaJugador: DTOApuestaJugador;
  public ApuestaEquipo: DTOApuestaEquipo;

  private _usuarioId: number;

  constructor(private http: HttpClient) {
    this.connect = new Conexion();

    this.ApuestaVof = new DTOApuestaVOF();
    this.ApuestaCantidad = new DTOApuestaCantidad();
    this.ApuestaJugador = new DTOApuestaJugador();
    this.ApuestaEquipo = new DTOApuestaEquipo();

    this._usuarioId = 3;
  }

  public AgregarApuestaVof(IdLogro: number, opcionVof: boolean) {
    this.connect.Controlador = 'registrarapuestavof';
    const url = this.connect.RutaApi + this.connect.Controlador;

    this.ApuestaVof.IdLogro = IdLogro;
    this.ApuestaVof.ApuestaUsuario = opcionVof;
    this.ApuestaVof.IdUsuario = this._usuarioId;

    this.http
      .put<DTOApuestaVOF>(url, this.ApuestaVof, { responseType: 'json' })
      .subscribe(
        data => {
          if (data != null) {
            console.log(data);
          } else {
            this.Succes('Apuesta Agregada Corectamente.');
          }
        },
        Error => {
          this.FatalError();
        }
      );

    return null;
  }

  public AgregarApuestaCantidad(IdLogro: number, opcionCantidad: number) {
    this.connect.Controlador = 'registrarapuestacantidad';
    const url = this.connect.RutaApi + this.connect.Controlador;

    this.ApuestaCantidad.IdLogro = IdLogro;
    this.ApuestaCantidad.ApuestaUsuario = opcionCantidad;
    this.ApuestaCantidad.IdUsuario = this._usuarioId;

    this.http
      .put<DTOApuestaCantidad>(url, this.ApuestaCantidad, {
        responseType: 'json'
      })
      .subscribe(
        data => {
          if (data != null) {
            console.log(data);
          } else {
            this.Succes('Apuesta Agregada Corectamente.');
          }
        },
        Error => {
          this.FatalError();
        }
      );

    return null;
  }

  public AgregarApuestaJugador(IdLogro: number, IdJugador: number) {
    this.connect.Controlador = 'registrarapuestajugador';
    const url = this.connect.RutaApi + this.connect.Controlador;

    this.ApuestaJugador.IdLogro = IdLogro;
    this.ApuestaJugador.IdJugador = IdJugador;
    this.ApuestaJugador.IdUsuario = this._usuarioId;

    this.http
      .put<DTOApuestaJugador>(url, this.ApuestaJugador, {
        responseType: 'json'
      })
      .subscribe(
        data => {
          if (data != null) {
            console.log(data);
          } else {
            this.Succes('Apuesta Agregada Corectamente.');
          }
        },
        Error => {
          this.FatalError();
        }
      );

    return null;
  }

  public AgregarApuestaEquipo(IdLogro: number, IdEquipo: number) {
    this.connect.Controlador = 'registrarapuestaequipo';
    const url = this.connect.RutaApi + this.connect.Controlador;

    this.ApuestaEquipo.IdLogro = IdLogro;
    this.ApuestaEquipo.IdEquipo = IdEquipo;
    this.ApuestaEquipo.IdUsuario = this._usuarioId;

    this.http
      .put<DTOApuestaEquipo>(url, this.ApuestaEquipo, {
        responseType: 'json'
      })
      .subscribe(
        data => {
          if (data != null) {
            console.log(data);
          } else {
            this.Succes('Apuesta Agregada Corectamente.');
          }
        },
        Error => {
          this.FatalError();
        }
      );

    return null;
  }

  public Error() {
    bootbox.alert();
  }

  public Succes(mensaje: string) {
    bootbox.alert(mensaje, function() {
      location.reload();
    });
  }

  public FatalError() {
    bootbox.alert('Problema al establecer la conexión con el servidor');
  }
}
