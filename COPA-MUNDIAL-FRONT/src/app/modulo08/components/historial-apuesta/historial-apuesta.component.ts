import { Component, OnInit } from '@angular/core';
import {
  Conexion,
  DTOApuestaVOF,
  DTOApuestaCantidad,
  DTOApuestaEquipo,
  DTOApuestaJugador,
  DTOEnviarIdUsuario
} from '../../models/index';
import { Api08Service } from '../../services/api08.service';
import { HttpClient } from '@angular/common/http';
import { Subject } from 'rxjs';

declare var bootbox: any;

@Component({
  selector: 'app-historial-apuesta',
  templateUrl: './historial-apuesta.component.html',
  styleUrls: ['./historial-apuesta.component.css',
    '../shared/style-apuesta.component.css']
})
export class HistorialApuestaComponent implements OnInit {

  public api08: Api08Service;
  public connect: Conexion;
  public dtoUsuario: DTOEnviarIdUsuario;

  public historialApuestaVof: DTOApuestaVOF;
  public historialApuestaCantidad: DTOApuestaCantidad;
  public historialApuestaJugador: DTOApuestaJugador;
  public historialApuestaEquipo: DTOApuestaEquipo;

  public ListHistorialApuestavof: DTOApuestaVOF[] = [];
  public ListHistorialApuestacantidad: DTOApuestaCantidad[] = [];
  public ListHistorialApuestajugadores: DTOApuestaJugador[] = [];
  public ListHistorialApuestaequipos: DTOApuestaEquipo[] = [];

  public dtTriggerHistorialVof: Subject<any> = new Subject();
  public dtTriggerHistorialCantidad: Subject<any> = new Subject();
  public dtTriggerHistorialJugadores: Subject<any> = new Subject();
  public dtTriggerHistorialEquipos: Subject<any> = new Subject();

  public dtOptionsHistorialVof: DataTables.Settings = {};
  public dtOptionsHistorialCantidad: DataTables.Settings = {};
  public dtOptionsHistorialJugadores: DataTables.Settings = {};
  public dtOptionsHistorialEquipos: DataTables.Settings = {};

  public idLogroJugador: number;

  constructor(private http: HttpClient) {
    this.api08 = new Api08Service(http);
    this.connect = new Conexion();
    this.dtoUsuario = new DTOEnviarIdUsuario();

    this.historialApuestaVof = new DTOApuestaVOF();
    this.historialApuestaCantidad = new DTOApuestaCantidad();
    this.historialApuestaJugador = new DTOApuestaJugador();
    this.historialApuestaEquipo = new DTOApuestaEquipo();
  }

  ngOnInit(): void {
    this.dtOptionsHistorialVof = {};
    this.dtOptionsHistorialCantidad = {};
    this.dtOptionsHistorialJugadores = {};
    this.dtOptionsHistorialEquipos = {};

    this.ObtenerHistorialApuestaVOF();
    this.ObtenerHistorialApuestaCantidad();
    this.ObtenerHistorialApuestaJugadores();
    this.ObtenerHistorialApuestaEquipos();
  }

  public ObtenerHistorialApuestaVOF() {
    this.connect.Controlador = 'obtenerapuestasvoffinalizadas';
    const url = this.connect.GetApiApuesta() + this.connect.Controlador;
    this.dtoUsuario.IdUsuario = this.connect.IdUsuario;

    this.http
      .put<DTOApuestaVOF>(url, this.dtoUsuario, { responseType: 'json' })
      .subscribe(
        data => {
          this.dtTriggerHistorialVof.next();
          for (let i = 0; i < Object.keys(data).length; i++) {
            let historialVOF: DTOApuestaVOF;
            historialVOF = new DTOApuestaVOF();

            historialVOF.IdLogro = data[i].IdLogro;
            historialVOF.Logro = data[i].Logro;
            historialVOF.ApuestaUsuario = data[i].ApuestaUsuario;
            historialVOF.Estado = data[i].Estado;
            historialVOF.Fecha = data[i].Fecha;

            this.ListHistorialApuestavof[i] = historialVOF;
          }
        },
        Error => {
          this.api08.FatalError();
        }
      );
  }

  public ObtenerHistorialApuestaCantidad() {
    this.connect.Controlador = 'obtenerapuestascantidadfinalizadas';
    const url = this.connect.GetApiApuesta() + this.connect.Controlador;
    this.dtoUsuario.IdUsuario = this.connect.IdUsuario;

    this.http
      .put<DTOApuestaCantidad>(url, this.dtoUsuario, {
        responseType: 'json'
      })
      .subscribe(
        data => {
          this.dtTriggerHistorialCantidad.next();
          for (let i = 0; i < Object.keys(data).length; i++) {
            let historialCantidad: DTOApuestaCantidad;
            historialCantidad = new DTOApuestaCantidad();

            historialCantidad.IdLogro = data[i].IdLogro;
            historialCantidad.Logro = data[i].Logro;
            historialCantidad.ApuestaUsuario = data[i].ApuestaUsuario;
            historialCantidad.Estado = data[i].Estado;
            historialCantidad.Fecha = data[i].Fecha;

            this.ListHistorialApuestacantidad[i] = historialCantidad;
          }
        },
        Error => {
          this.api08.FatalError();
        }
      );
  }

  public ObtenerHistorialApuestaJugadores() {
    this.connect.Controlador = 'obtenerapuestasjugadorfinalizadas';
    const url = this.connect.GetApiApuesta() + this.connect.Controlador;
    this.dtoUsuario.IdUsuario = this.connect.IdUsuario;

    this.http
      .put<DTOApuestaJugador>(url, this.dtoUsuario, {
        responseType: 'json'
      })
      .subscribe(
        data => {
          this.dtTriggerHistorialJugadores.next();
          for (let i = 0; i < Object.keys(data).length; i++) {
            let historialJugador: DTOApuestaJugador;
            historialJugador = new DTOApuestaJugador();

            historialJugador.IdLogro = data[i].IdLogro;
            historialJugador.Logro = data[i].Logro;
            historialJugador.NombreJugador = data[i].NombreJugador;
            historialJugador.ApellidoJugador = data[i].ApellidoJugador;
            historialJugador.Estado = data[i].Estado;
            historialJugador.Fecha = data[i].Fecha;

            this.ListHistorialApuestajugadores[i] = historialJugador;
          }
        },
        Error => {
          this.api08.FatalError();
        }
      );
  }

  public ObtenerHistorialApuestaEquipos() {
    this.connect.Controlador = 'obtenerapuestasequipofinalizadas';
    const url = this.connect.GetApiApuesta() + this.connect.Controlador;
    this.dtoUsuario.IdUsuario = this.connect.IdUsuario;

    this.http
      .put<DTOApuestaEquipo>(url, this.dtoUsuario, { responseType: 'json' })
      .subscribe(
        data => {
          this.dtTriggerHistorialEquipos.next();
          for (let i = 0; i < Object.keys(data).length; i++) {
            let historialEquipo: DTOApuestaEquipo;
            historialEquipo = new DTOApuestaEquipo();

            historialEquipo.IdLogro = data[i].IdLogro;
            historialEquipo.Logro = data[i].Logro;
            historialEquipo.NombreEquipo = data[i].NombreEquipo;
            historialEquipo.Estado = data[i].Estado;
            historialEquipo.Fecha = data[i].Fecha;

            this.ListHistorialApuestaequipos[i] = historialEquipo;
          }
        },
        Error => {
          this.api08.FatalError();
        }
      );
  }
}
