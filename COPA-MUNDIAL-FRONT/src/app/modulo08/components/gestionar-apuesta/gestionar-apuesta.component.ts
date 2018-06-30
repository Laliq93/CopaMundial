import { Component, OnInit } from '@angular/core';
import {
  Conexion,
  DTOApuestaVOF,
  DTOApuestaCantidad,
  DTOApuestaEquipo,
  DTOApuestaJugador,
  DTOEnviarIdUsuario,
  DTOMostrarJugador
} from '../../models/index';
import { Api08Service } from '../../services/api08.service';
import { HttpClient } from '@angular/common/http';
import { Subject } from 'rxjs';

declare var bootbox: any;

@Component({
  selector: 'app-gestionar-apuesta',
  templateUrl: './gestionar-apuesta.component.html',
  styleUrls: [
    './gestionar-apuesta.component.css',
    '../shared/style-apuesta.component.css'
  ]
})
export class GestionarApuestaComponent implements OnInit {

  public api08: Api08Service;
  public connect: Conexion;
  public dtoUsuario: DTOEnviarIdUsuario;
  public MostrarJugadores: DTOMostrarJugador;

  public ApuestaVof: DTOApuestaVOF;
  public ApuestaCantidad: DTOApuestaCantidad;
  public ApuestaJugador: DTOApuestaJugador;
  public ApuestaEquipo: DTOApuestaEquipo;

  public ListApuestavof: DTOApuestaVOF[] = [];
  public ListApuestacantidad: DTOApuestaCantidad[] = [];
  public ListApuestajugadores: DTOApuestaJugador[] = [];
  public ListApuestaequipos: DTOApuestaEquipo[] = [];
  public ListMostrarJugadores: DTOMostrarJugador[] = [];

  public dtTriggerApuestaVof: Subject<any> = new Subject();
  public dtTriggerApuestaCantidad: Subject<any> = new Subject();
  public dtTriggerApuestaJugadores: Subject<any> = new Subject();
  public dtTriggerApuestaEquipos: Subject<any> = new Subject();
  public dtTriggerMostrarJugadores: Subject<any> = new Subject();

  public dtOptionsApuestaVof: DataTables.Settings = {};
  public dtOptionsApuestaCantidad: DataTables.Settings = {};
  public dtOptionsApuestaJugadores: DataTables.Settings = {};
  public dtOptionsApuestaEquipos: DataTables.Settings = {};
  public dtOptionsMostrarJugadores: DataTables.Settings = {};

  public actualizarOpcionVof: boolean[] = [];
  public actualizarOpcionCantidad: number[] = [];
  public actualizarOpcionJugador: number;
  public actualizarOpcionEquipo: number[] = [];

  public idLogroJugador: number;
  public display = 'none';

  constructor(private http: HttpClient) {
    this.api08 = new Api08Service(http);
    this.connect = new Conexion();
    this.dtoUsuario = new DTOEnviarIdUsuario();

    this.ApuestaVof = new DTOApuestaVOF();
    this.ApuestaCantidad = new DTOApuestaCantidad();
    this.ApuestaJugador = new DTOApuestaJugador();
    this.ApuestaEquipo = new DTOApuestaEquipo();
  }

  ngOnInit(): void {
    this.dtOptionsApuestaVof = {};
    this.dtOptionsApuestaCantidad = {};
    this.dtOptionsApuestaJugadores = {};
    this.dtOptionsApuestaEquipos = {};

    this.ObtenerApuestaVOF();
    this.ObtenerApuestaCantidad();
    this.ObtenerApuestaEquipos();
    this.ObtenerApuestaJugadores();
  }

  public ObtenerApuestaVOF() {
    this.connect.Controlador = 'obtenerapuestasvofencurso';
    const url = this.connect.GetApiApuesta() + this.connect.Controlador;
    this.dtoUsuario.IdUsuario = this.connect.IdUsuario;

    this.http
      .put<DTOApuestaVOF>(url, this.dtoUsuario, { responseType: 'json' })
      .subscribe(
        data => {
          this.dtTriggerApuestaVof.next();
          for (let i = 0; i < Object.keys(data).length; i++) {
            let apuestasVOF: DTOApuestaVOF;
            apuestasVOF = new DTOApuestaVOF();

            apuestasVOF.IdLogro = data[i].IdLogro;
            apuestasVOF.Logro = data[i].Logro;
            apuestasVOF.ApuestaUsuario = data[i].ApuestaUsuario;
            apuestasVOF.Estado = data[i].Estado;
            apuestasVOF.Fecha = data[i].Fecha;

            this.ListApuestavof[i] = apuestasVOF;
          }
        },
        Error => {
          this.api08.FatalError(Error);
        }
      );
  }

  public ObtenerApuestaCantidad() {
    this.connect.Controlador = 'obtenerapuestascantidadencurso';
    const url = this.connect.GetApiApuesta() + this.connect.Controlador;
    this.dtoUsuario.IdUsuario = this.connect.IdUsuario;

    this.http
      .put<DTOApuestaCantidad>(url, this.dtoUsuario, {
        responseType: 'json'
      })
      .subscribe(
        data => {
          this.dtTriggerApuestaCantidad.next();
          for (let i = 0; i < Object.keys(data).length; i++) {
            let apuestasCantidad: DTOApuestaCantidad;
            apuestasCantidad = new DTOApuestaCantidad();

            apuestasCantidad.IdLogro = data[i].IdLogro;
            apuestasCantidad.Logro = data[i].Logro;
            apuestasCantidad.ApuestaUsuario = data[i].ApuestaUsuario;
            apuestasCantidad.Estado = data[i].Estado;
            apuestasCantidad.Fecha = data[i].Fecha;

            this.ListApuestacantidad[i] = apuestasCantidad;
          }
        },
        Error => {
          this.api08.FatalError(Error);
        }
      );
  }

  public ObtenerApuestaJugadores() {
    this.connect.Controlador = 'obtenerapuestasjugadorencurso';
    const url = this.connect.GetApiApuesta() + this.connect.Controlador;
    this.dtoUsuario.IdUsuario = this.connect.IdUsuario;

    this.http
      .put<DTOApuestaJugador>(url, this.dtoUsuario, {
        responseType: 'json'
      })
      .subscribe(
        data => {
          this.dtTriggerApuestaJugadores.next();
          for (let i = 0; i < Object.keys(data).length; i++) {
            let apuestasJugador: DTOApuestaJugador;
            apuestasJugador = new DTOApuestaJugador();

            apuestasJugador.IdLogro = data[i].IdLogro;
            apuestasJugador.Logro = data[i].Logro;
            apuestasJugador.NombreJugador = data[i].NombreJugador;
            apuestasJugador.ApellidoJugador = data[i].ApellidoJugador;
            apuestasJugador.Estado = data[i].Estado;
            apuestasJugador.Fecha = data[i].Fecha;

            this.ListApuestajugadores[i] = apuestasJugador;
          }
        },
        Error => {
          this.api08.FatalError(Error);
        }
      );
  }

  public ObtenerApuestaEquipos() {
    this.connect.Controlador = 'obtenerapuestasequipoencurso';
    const url = this.connect.GetApiApuesta() + this.connect.Controlador;
    this.dtoUsuario.IdUsuario = this.connect.IdUsuario;

    this.http
      .put<DTOApuestaEquipo>(url, this.dtoUsuario, { responseType: 'json' })
      .subscribe(
        data => {
          this.dtTriggerApuestaEquipos.next();
          for (let i = 0; i < Object.keys(data).length; i++) {
            let logrosEquipo: DTOApuestaEquipo;
            logrosEquipo = new DTOApuestaEquipo();

            logrosEquipo.IdLogro = data[i].IdLogro;
            logrosEquipo.Logro = data[i].Logro;
            logrosEquipo.NombreEquipo = data[i].NombreEquipo;
            logrosEquipo.Estado = data[i].Estado;
            logrosEquipo.Fecha = data[i].Fecha;

            this.ListApuestaequipos[i] = logrosEquipo;
          }
        },
        Error => {
          this.api08.FatalError(Error);
        }
      );
  }

  public ObtenerListaJugadoresPartido() {
    this.connect.Controlador = 'obtenerJugadores';
    const url = this.connect.GetApiJugador() + this.connect.Controlador;

    this.http
      .get<DTOMostrarJugador>(url, {
        responseType: 'json'
      })
      .subscribe(
        data => {
          this.dtTriggerMostrarJugadores.next();
          for (let i = 0; i < Object.keys(data).length; i++) {
            let listaJugadores: DTOMostrarJugador;
            listaJugadores = new DTOMostrarJugador();

            listaJugadores.Id = data[i].Id;
            listaJugadores.Nombre = data[i].Nombre;
            listaJugadores.Apellido = data[i].Apellido;

            this.ListMostrarJugadores[i] = listaJugadores;
          }
        },
        Error => {
          this.api08.FatalError(Error);
        }
      );
  }

  public ActualizarApuestaVof(IdLogro, actualizarvof: boolean) {
    if (actualizarvof) {
      this.api08.ActualizarApuestaVof(IdLogro, actualizarvof);
    } else {
      bootbox.alert('Debes seleccionar una opción Valida');
    }
  }

  public ActualizarApuestaCantidad(IdLogro, actualizarCantidad: number) {
    if (actualizarCantidad) {
      this.api08.ActualizarApuestaCantidad(IdLogro, actualizarCantidad);
    } else {
      bootbox.alert('Debes Ingresar una Cantidad Valida');
    }
  }

  public ActualizarApuestaJugador(IdJugador: number) {
    if (IdJugador) {
      this.api08.ActualizarApuestaJugador(this.idLogroJugador, IdJugador);
      this.closeModalJuagdores();
    } else {
      bootbox.alert('Debes escoger un jugador Valido');
    }
  }

  public ActualizarApuestaEquipo(IdLogro, IdEquipo: number) {
    if (IdEquipo) {
      this.api08.ActualizarApuestaEquipo(IdLogro, IdEquipo);
    } else {
      bootbox.alert('Debes escoger un equipo Valido');
    }
  }

  public EliminarApuestaVof(IdLogro) {
    if (IdLogro) {
      this.api08.EliminarApuestaVof(IdLogro);
    } else {
      bootbox.alert('No hemos podido Realizar tu Solicitud');
    }
  }

  public EliminarApuestaCantidad(IdLogro) {
    if (IdLogro) {
      this.api08.EliminarApuestaCantidad(IdLogro);
    } else {
      bootbox.alert('No hemos podido Realizar tu Solicitud');
    }
  }

  public EliminarApuestaJugador(IdLogro) {
    if (IdLogro) {
      this.api08.EliminarApuestaJugador(IdLogro);
      this.closeModalJuagdores();
    } else {
      bootbox.alert('No hemos podido Realizar tu Solicitud');
    }
  }

  public EliminarApuestaEquipo(IdLogro) {
    if (IdLogro) {
      this.api08.EliminarApuestaEquipo(IdLogro);
    } else {
      bootbox.alert('No hemos podido Realizar tu Solicitud');
    }
  }

  public openModaljugadores(idLogro) {
    this.idLogroJugador = idLogro;
    this.ObtenerListaJugadoresPartido();
    this.display = 'block';
  }

  public closeModalJuagdores() {
    this.display = 'none';
  }

  public ObtenerVoF(apuesta) {
    if (apuesta) {
      return 'Si';
    }
    return 'No';
  }
}
