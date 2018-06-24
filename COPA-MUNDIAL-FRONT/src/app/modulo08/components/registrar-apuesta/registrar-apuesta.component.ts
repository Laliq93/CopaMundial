import { Component, OnInit } from '@angular/core';
import { DTOMostrarPartido, Conexion } from '../../models/index';
import { Api08Service } from '../../services/api08.service';
import { HttpClient } from '@angular/common/http';
import { Subject } from 'rxjs';

declare var bootbox: any;

@Component({
  selector: 'app-registrar-apuesta',
  templateUrl: './registrar-apuesta.component.html',
  styleUrls: [
    './registrar-apuesta.component.css',
    '../shared/style-apuesta.component.css'
  ]
})
export class RegistrarApuestaComponent implements OnInit {
  public MostrarPartido: DTOMostrarPartido;
  public api08: Api08Service;
  public ListMostrarPartido: DTOMostrarPartido[] = [];
  public connect: Conexion;

  public dtTrigger: Subject<any> = new Subject();
  public dtOptions: DataTables.Settings = {};

  constructor(private http: HttpClient) {
    this.api08 = new Api08Service(http);
    this.MostrarPartido = new DTOMostrarPartido();
    this.connect = new Conexion();
  }

  ngOnInit(): void {
    this.dtOptions = {};

    this.ObtenerProximosPartidos();
  }

  public ObtenerProximosPartidos() {
    this.connect.Controlador = 'obtenerproximospartidos';
    let url = this.connect.RutaApi + this.connect.Controlador;

    this.http.get<DTOMostrarPartido>(url, { responseType: 'json' }).subscribe(
      data => {
        this.dtTrigger.next();
        for (let i = 0; i < Object.keys(data).length; i++) {
          let partido: DTOMostrarPartido;

          partido = new DTOMostrarPartido();

          partido.Id = data[i].IdPartido;
          partido.Equipo1 = data[i].Equipo1;
          partido.Equipo2 = data[i].Equipo2;
          partido.FechaPartido = data[i].Fecha;

          this.ListMostrarPartido[i] = partido;
        }
      },
      Error => {
        this.api08.FatalError();
      }
    );
  }

  VerApuestasPartido(IdPartido) {
    this.api08.EnviarIdApuestaPartido(IdPartido);
  }
}
