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

  constructor(private http: HttpClient) {
    this.connect = new Conexion();

    this.ApuestaVof = new DTOApuestaVOF();
    this.ApuestaCantidad = new DTOApuestaCantidad();
    this.ApuestaJugador = new DTOApuestaJugador();
    this.ApuestaEquipo = new DTOApuestaEquipo();
  }

  public AgregarApuestaVof(IdLogro: number, opcionVof: boolean) {
    this.connect.Controlador = 'registrarapuestavof';
    const url = this.connect.GetApiApuesta() + this.connect.Controlador;

    this.ApuestaVof.IdLogro = IdLogro;
    this.ApuestaVof.ApuestaUsuario = opcionVof;
    this.ApuestaVof.IdUsuario = this.connect.IdUsuario;

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
          this.FatalError(Error);
        }
      );

    return null;
  }

  public AgregarApuestaCantidad(IdLogro: number, opcionCantidad: number) {
    this.connect.Controlador = 'registrarapuestacantidad';
    const url = this.connect.GetApiApuesta() + this.connect.Controlador;

    this.ApuestaCantidad.IdLogro = IdLogro;
    this.ApuestaCantidad.ApuestaUsuario = opcionCantidad;
    this.ApuestaCantidad.IdUsuario = this.connect.IdUsuario;

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
          this.FatalError(Error);
        }
      );

    return null;
  }

  public AgregarApuestaJugador(IdLogro: number, IdJugador: number) {
    this.connect.Controlador = 'registrarapuestajugador';
    const url = this.connect.GetApiApuesta() + this.connect.Controlador;

    this.ApuestaJugador.IdLogro = IdLogro;
    this.ApuestaJugador.IdJugador = IdJugador;
    this.ApuestaJugador.IdUsuario = this.connect.IdUsuario;

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
          this.FatalError(Error);
        }
      );

    return null;
  }

  public AgregarApuestaEquipo(IdLogro: number, IdEquipo: number) {
    this.connect.Controlador = 'registrarapuestaequipo';
    const url = this.connect.GetApiApuesta() + this.connect.Controlador;

    this.ApuestaEquipo.IdLogro = IdLogro;
    this.ApuestaEquipo.IdEquipo = IdEquipo;
    this.ApuestaEquipo.IdUsuario = this.connect.IdUsuario;

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
          this.FatalError(Error);
        }
      );

    return null;
  }

  public ActualizarApuestaVof(IdLogro: number, opcionVof: boolean) {
    this.connect.Controlador = 'actualizarapuestavof';
    const url = this.connect.GetApiApuesta() + this.connect.Controlador;

    this.ApuestaVof.IdLogro = IdLogro;
    this.ApuestaVof.ApuestaUsuario = opcionVof;
    this.ApuestaVof.IdUsuario = this.connect.IdUsuario;

    this.http
      .put<DTOApuestaVOF>(url, this.ApuestaVof, { responseType: 'json' })
      .subscribe(
        data => {
          if (data != null) {
            console.log(data);
          } else {
            this.Succes('Se Actualizo tu Apuesta Corectamente.');
          }
        },
        Error => {
          this.FatalError(Error);
        }
      );

    return null;
  }

  public ActualizarApuestaCantidad(IdLogro: number, opcionCantidad: number) {
    this.connect.Controlador = 'actualizarapuestacantidad';
    const url = this.connect.GetApiApuesta() + this.connect.Controlador;

    this.ApuestaCantidad.IdLogro = IdLogro;
    this.ApuestaCantidad.ApuestaUsuario = opcionCantidad;
    this.ApuestaCantidad.IdUsuario = this.connect.IdUsuario;

    this.http
      .put<DTOApuestaCantidad>(url, this.ApuestaCantidad, {
        responseType: 'json'
      })
      .subscribe(
        data => {
          if (data != null) {
            console.log(data);
          } else {
            this.Succes('Se Actualizo tu Apuesta Corectamente.');
          }
        },
        Error => {
          this.FatalError(Error);
        }
      );

    return null;
  }

  public ActualizarApuestaJugador(IdLogro: number, IdJugador: number) {
    this.connect.Controlador = 'actualizarapuestajugador';
    const url = this.connect.GetApiApuesta() + this.connect.Controlador;

    this.ApuestaJugador.IdLogro = IdLogro;
    this.ApuestaJugador.IdJugador = IdJugador;
    this.ApuestaJugador.IdUsuario = this.connect.IdUsuario;

    this.http
      .put<DTOApuestaJugador>(url, this.ApuestaJugador, {
        responseType: 'json'
      })
      .subscribe(
        data => {
          if (data != null) {
            console.log(data);
          } else {
            this.Succes('Se Actualizo tu Apuesta Corectamente.');
          }
        },
        Error => {
          this.FatalError(Error);
        }
      );

    return null;
  }

  public ActualizarApuestaEquipo(IdLogro: number, IdEquipo: number) {
    this.connect.Controlador = 'actualizarapuestaequipo';
    const url = this.connect.GetApiApuesta() + this.connect.Controlador;

    this.ApuestaEquipo.IdLogro = IdLogro;
    this.ApuestaEquipo.IdEquipo = IdEquipo;
    this.ApuestaEquipo.IdUsuario = this.connect.IdUsuario;

    this.http
      .put<DTOApuestaEquipo>(url, this.ApuestaEquipo, {
        responseType: 'json'
      })
      .subscribe(
        data => {
          if (data != null) {
            console.log(data);
          } else {
            this.Succes('Se Actualizo tu Apuesta Corectamente.');
          }
        },
        Error => {
          this.FatalError(Error);
        }
      );

    return null;
  }

  public EliminarApuestaVof(IdLogro: number) {
    this.connect.Controlador = 'eliminarapuestavof';
    const url = this.connect.GetApiApuesta() + this.connect.Controlador;

    this.ApuestaVof.IdLogro = IdLogro;
    this.ApuestaVof.IdUsuario = this.connect.IdUsuario;

    this.http
      .put<DTOApuestaVOF>(url, this.ApuestaVof, { responseType: 'json' })
      .subscribe(
        data => {
          if (data != null) {
            console.log(data);
          } else {
            this.Succes('Apuesta Eliminada Corectamente.');
          }
        },
        Error => {
          this.FatalError(Error);
        }
      );

    return null;
  }

  public EliminarApuestaCantidad(IdLogro: number) {
    this.connect.Controlador = 'eliminarapuestacantidad';
    const url = this.connect.GetApiApuesta() + this.connect.Controlador;

    this.ApuestaCantidad.IdLogro = IdLogro;
    this.ApuestaCantidad.IdUsuario = this.connect.IdUsuario;

    this.http
      .put<DTOApuestaCantidad>(url, this.ApuestaCantidad, {
        responseType: 'json'
      })
      .subscribe(
        data => {
          if (data != null) {
            console.log(data);
          } else {
            this.Succes('Apuesta Eliminada Corectamente.');
          }
        },
        Error => {
          this.FatalError(Error);
        }
      );

    return null;
  }

  public EliminarApuestaJugador(IdLogro: number) {
    this.connect.Controlador = 'eliminarapuestajugador';
    const url = this.connect.GetApiApuesta() + this.connect.Controlador;

    this.ApuestaJugador.IdLogro = IdLogro;
    this.ApuestaJugador.IdUsuario = this.connect.IdUsuario;

    this.http
      .put<DTOApuestaJugador>(url, this.ApuestaJugador, {
        responseType: 'json'
      })
      .subscribe(
        data => {
          if (data != null) {
            console.log(data);
          } else {
            this.Succes('Apuesta Eliminada Corectamente.');
          }
        },
        Error => {
          this.FatalError(Error);
        }
      );

    return null;
  }

  public EliminarApuestaEquipo(IdLogro: number) {
    this.connect.Controlador = 'eliminarapuestaequipo';
    const url = this.connect.GetApiApuesta() + this.connect.Controlador;

    this.ApuestaEquipo.IdLogro = IdLogro;
    this.ApuestaEquipo.IdUsuario = this.connect.IdUsuario;

    this.http
      .put<DTOApuestaEquipo>(url, this.ApuestaEquipo, {
        responseType: 'json'
      })
      .subscribe(
        data => {
          if (data != null) {
            console.log(data);
          } else {
            this.Succes('Apuesta Eliminada Corectamente.');
          }
        },
        Error => {
          this.FatalError(Error);
        }
      );

    return null;
  }

  public Succes(mensaje: string) {
    bootbox.alert(mensaje, function() {
      location.reload();
    });
  }

  public FatalError(Error) {
    
    if(Error.status == 0){
      bootbox.alert('Problema al establecer la conexión con el servidor');
      return;
    }

    bootbox.alert(Error.error);
  }
}
