import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import {
  DTOEnviarIdPartido,
  DTOMostrarLogros,
  DTOApuestaVOF,
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
  public ListMostrarlogro: DTOMostrarLogros[] = [];
  public MostrarTipoLogro: DTOApuestaVOF;
  public api08: Api08Service;

  public connect: Conexion;

  public dtTrigger: Subject<any> = new Subject();
  public dtOptions: DataTables.Settings = {};

  public idPartido: number;

  constructor(private http: HttpClient, private router: ActivatedRoute) {
    this.api08 = new Api08Service(http);
    this.EnviarIdPartido = new DTOEnviarIdPartido();
    this.MostrarLogros = new DTOMostrarLogros();

    this.connect = new Conexion();
  }

  ngOnInit(): void {
    this.dtOptions = {};
    this.idPartido = parseInt(this.router.snapshot.paramMap.get('idPartido'), 10);

    this.ObtenerLogrosVOF();
    this.ObtenerLogrosCantidad();
    this.ObtenerLogrosEquipos();
    this.ObtenerLogrosJugadores();
  }

  public ObtenerLogrosVOF() {
    this.connect.Controlador = 'obtenerlogrosvofpartido';
    let url = this.connect.RutaApi + this.connect.Controlador;
    this.EnviarIdPartido.IdPartido = this.idPartido;

    this.http
      .put<DTOMostrarLogros>(url, this.EnviarIdPartido, {
        responseType: 'json'
      })
      .subscribe(
        data => {},
        Error => {
          this.api08.FatalError();
        }
      );
  }

  public ObtenerLogrosCantidad() {
    this.connect.Controlador = 'obtenerlogroscantidadpartido';
    let url = this.connect.RutaApi + this.connect.Controlador;
    this.EnviarIdPartido.IdPartido = this.idPartido;

    this.http
      .put<DTOMostrarLogros>(url, this.EnviarIdPartido, {
        responseType: 'json'
      })
      .subscribe(
        data => {},
        Error => {
          this.api08.FatalError();
        }
      );
  }

  public ObtenerLogrosJugadores() {
    this.connect.Controlador = 'obtenerlogrosjugadorespartido';
    let url = this.connect.RutaApi + this.connect.Controlador;
    this.EnviarIdPartido.IdPartido = this.idPartido;

    this.http
      .put<DTOMostrarLogros>(url, this.EnviarIdPartido, {
        responseType: 'json'
      })
      .subscribe(
        data => {},
        Error => {
          this.api08.FatalError();
        }
      );
  }

  public ObtenerLogrosEquipos() {
    this.connect.Controlador = 'obtenerlogrosequipospartido';
    let url = this.connect.RutaApi + this.connect.Controlador;
    this.EnviarIdPartido.IdPartido = this.idPartido;

    this.http
      .put<DTOMostrarLogros>(url, this.EnviarIdPartido, {
        responseType: 'json'
      })
      .subscribe(
        data => {},
        Error => {
          this.api08.FatalError();
        }
      );
  }
}
