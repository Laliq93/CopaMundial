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
  public idLogroJugador: number;
  public opcionVof: boolean[] = [];
  public opcionCantidad: number[] = [];
  public opcionJugador: number;
  public opcionEquipo: number[] = [];

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
    this.connect.Controlador = 'obtenerLogrosVFPendiente';
    const url = this.connect.GetApiLogro() + this.connect.Controlador;
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
          console.log(Error.error);
        }
      );
  }

  public ObtenerLogrosCantidad() {
    this.connect.Controlador = 'obtenerLogrosCantidadPendiente';
    const url = this.connect.GetApiLogro() + this.connect.Controlador;
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
          console.log(Error.error);
        }
      );
  }

  public ObtenerLogrosJugadores() {
    this.connect.Controlador = 'obtenerLogrosJugadorPendiente';
    const url = this.connect.GetApiLogro() + this.connect.Controlador;
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
          console.log(Error.error);
        }
      );
  }

  public ObtenerLogrosEquipos() {
    this.connect.Controlador = 'obtenerLogrosEquipoPendiente';
    const url = this.connect.GetApiLogro() + this.connect.Controlador;
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
          console.log(Error.error);
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

  public ApostarVof(IdLogro, opcionVof: boolean) {
    if (opcionVof) {
      this.api08.AgregarApuestaVof(IdLogro, opcionVof);
    } else {
      bootbox.alert('Debes seleccionar una opción Valida');
    }
  }

  public ApostarCantidad(IdLogro, opcionCantidad: number) {
    if (opcionCantidad) {
      this.api08.AgregarApuestaCantidad(IdLogro, opcionCantidad);
    } else {
      bootbox.alert('Debes Ingresar una Cantidad Valida');
    }
  }

  public ApostarJugador(IdJugador: number) {
    if (IdJugador) {
      this.api08.AgregarApuestaJugador(this.idLogroJugador, IdJugador);
      this.closeModalJuagdores();
    } else {
      bootbox.alert('Debes escoger un jugador Valido');
    }
  }

  public ApostarEquipo(IdLogro, IdEquipo: number) {
    if (IdEquipo) {
      this.api08.AgregarApuestaEquipo(IdLogro, IdEquipo);
    } else {
      bootbox.alert('Debes escoger un equipo Valido');
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
}
