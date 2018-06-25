import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import {
  DTOEnviarIdPartido,
  DTOMostrarLogros,
  DTOMostrarJugador,
  Conexion
} from '../../models/index';
import { Api08Service } from '../../services/api08.service';
import { HttpClient } from '@angular/common/http';
import { Subject } from 'rxjs';

declare var bootbox: any;

@Component({
  selector: 'app-ver-apuesta',
  templateUrl: './ver-apuesta.component.html',
  styleUrls: [
    './ver-apuesta.component.css',
    '../shared/style-apuesta.component.css'
  ]
})
export class VerApuestaComponent implements OnInit {
  public EnviarIdPartido: DTOEnviarIdPartido;
  public MostrarLogros: DTOMostrarLogros;
  public MostrarJugadores: DTOMostrarJugador;

  public api08: Api08Service;
  public connect: Conexion;

  public ListMostrarlogrovof: DTOMostrarLogros[] = [];
  public ListMostrarlogrocantidad: DTOMostrarLogros[] = [];
  public ListMostrarlogrojugadores: DTOMostrarLogros[] = [];
  public ListMostrarlogroequipos: DTOMostrarLogros[] = [];
  public ListMostrarJugadores: DTOMostrarJugador[] = [];

  public dtTriggerVof: Subject<any> = new Subject();
  public dtTriggerCantidad: Subject<any> = new Subject();
  public dtTriggerJugadores: Subject<any> = new Subject();
  public dtTriggerEquipos: Subject<any> = new Subject();
  public dtTriggerMostrarJugadores: Subject<any> = new Subject();

  public dtOptionsVof: DataTables.Settings = {};
  public dtOptionsCantidad: DataTables.Settings = {};
  public dtOptionsJugadores: DataTables.Settings = {};
  public dtOptionsEquipos: DataTables.Settings = {};
  public dtOptionsMostrarJugadores: DataTables.Settings = {};

  public idPartido: number;
  public opcionVof: boolean[] = [];
  public opcionCantidad: number[] = [];
  public opcionJugador: number;
  public opcionEquipo: number;

  public display = 'none';

  constructor(private http: HttpClient, private router: ActivatedRoute) {
    this.api08 = new Api08Service(http);
    this.EnviarIdPartido = new DTOEnviarIdPartido();
    this.MostrarLogros = new DTOMostrarLogros();
    this.MostrarJugadores = new DTOMostrarJugador();
    this.connect = new Conexion();
  }

  ngOnInit(): void {
    this.dtOptionsVof = {};
    this.dtOptionsCantidad = {};
    this.dtOptionsJugadores = {};
    this.dtOptionsEquipos = {};
    this.dtOptionsMostrarJugadores = {};

    this.idPartido = parseInt(
      this.router.snapshot.paramMap.get('idPartido'),
      10
    );

    this.ObtenerLogrosVOF();
    this.ObtenerLogrosCantidad();
    this.ObtenerLogrosEquipos();
    this.ObtenerLogrosJugadores();
  }

  public ObtenerLogrosVOF() {
    this.connect.Controlador = 'obtenerlogrosvofpartido';
    const url = this.connect.RutaApi + this.connect.Controlador;
    this.EnviarIdPartido.IdPartido = this.idPartido;

    this.http
      .put<DTOMostrarLogros>(url, this.EnviarIdPartido, {
        responseType: 'json'
      })
      .subscribe(
        data => {
          this.dtTriggerVof.next();
          for (let i = 0; i < Object.keys(data).length; i++) {
            let logrosVOF: DTOMostrarLogros;
            logrosVOF = new DTOMostrarLogros();

            logrosVOF.IdLogro = data[i].IdLogro;
            logrosVOF.Logro = data[i].Logro;

            this.ListMostrarlogrovof[i] = logrosVOF;
          }
        },
        Error => {
          this.api08.FatalError();
        }
      );
  }

  public ObtenerLogrosCantidad() {
    this.connect.Controlador = 'obtenerlogroscantidadpartido';
    const url = this.connect.RutaApi + this.connect.Controlador;
    this.EnviarIdPartido.IdPartido = this.idPartido;

    this.http
      .put<DTOMostrarLogros>(url, this.EnviarIdPartido, {
        responseType: 'json'
      })
      .subscribe(
        data => {
          this.dtTriggerCantidad.next();
          for (let i = 0; i < Object.keys(data).length; i++) {
            let logrosCantidad: DTOMostrarLogros;
            logrosCantidad = new DTOMostrarLogros();

            logrosCantidad.IdLogro = data[i].IdLogro;
            logrosCantidad.Logro = data[i].Logro;

            this.ListMostrarlogrocantidad[i] = logrosCantidad;
          }
        },
        Error => {
          this.api08.FatalError();
        }
      );
  }

  public ObtenerLogrosJugadores() {
    this.connect.Controlador = 'obtenerlogrosjugadorpartido';
    const url = this.connect.RutaApi + this.connect.Controlador;
    this.EnviarIdPartido.IdPartido = this.idPartido;

    this.http
      .put<DTOMostrarLogros>(url, this.EnviarIdPartido, {
        responseType: 'json'
      })
      .subscribe(
        data => {
          this.dtTriggerJugadores.next();
          for (let i = 0; i < Object.keys(data).length; i++) {
            let logrosJugador: DTOMostrarLogros;
            logrosJugador = new DTOMostrarLogros();

            logrosJugador.IdLogro = data[i].IdLogro;
            logrosJugador.Logro = data[i].Logro;

            this.ListMostrarlogrojugadores[i] = logrosJugador;
          }
        },
        Error => {
          this.api08.FatalError();
        }
      );
  }

  public ObtenerLogrosEquipos() {
    this.connect.Controlador = 'obtenerlogrosequipopartido';
    const url = this.connect.RutaApi + this.connect.Controlador;
    this.EnviarIdPartido.IdPartido = this.idPartido;

    this.http
      .put<DTOMostrarLogros>(url, this.EnviarIdPartido, {
        responseType: 'json'
      })
      .subscribe(
        data => {
          this.dtTriggerEquipos.next();
          for (let i = 0; i < Object.keys(data).length; i++) {
            let logrosEquipo: DTOMostrarLogros;
            logrosEquipo = new DTOMostrarLogros();

            logrosEquipo.IdLogro = data[i].IdLogro;
            logrosEquipo.Logro = data[i].Logro;

            this.ListMostrarlogroequipos[i] = logrosEquipo;
          }
        },
        Error => {
          this.api08.FatalError();
        }
      );
  }

  public ObtenerListaJugadoresPartido() {
    this.connect.Controlador = 'obtenerlistajugadorespartido';
    const url = this.connect.RutaApi + this.connect.Controlador;

    this.http
      .put<DTOMostrarJugador>(url, {
        responseType: 'json'
      })
      .subscribe(
        data => {
          this.dtTriggerMostrarJugadores.next();
          for (let i = 0; i < Object.keys(data).length; i++) {
            let listaJugadores: DTOMostrarJugador;
            listaJugadores = new DTOMostrarJugador();

            listaJugadores.IdJugador = data[i].IdLogro;
            listaJugadores.Nombre = data[i].Logro;
            listaJugadores.Apellido = data[i].Logro;

            this.ListMostrarJugadores[i] = listaJugadores;
          }
        },
        Error => {
          this.api08.FatalError();
        }
      );
  }

  public ApostarVof(IdLogro, opcionVof) {
    this.api08.AgregarApuestaVof(IdLogro, opcionVof);
  }

  public ApostarCantidad(IdLogro, opcionCantidad: number) {
    alert(opcionCantidad);
    this.api08.AgregarApuestaCantidad(IdLogro, opcionCantidad);
  }

  public ApostarJugador(IdJugador) {}

  public ApostarEquipo() {}

  public openModaljugadores() {
    this.display = 'block';
  }

  public closeModalJuagdores() {
    this.display = 'none';
  }
}
