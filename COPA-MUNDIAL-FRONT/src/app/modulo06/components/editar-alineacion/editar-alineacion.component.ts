import { Component, AfterViewInit } from '@angular/core';
import { Location } from '@angular/common';
import { Router, ActivatedRoute } from '@angular/router';
import { PartidoService } from '../../services/partido.service';

import { Jugador } from '../../models/jugador';
import { Partido } from '../../models/partido';
import { Alineacion } from '../../models/alineacion';
import { Equipo } from '../../models/equipo';

@Component({
  selector: 'app-editar-alineacion',
  templateUrl: './editar-alineacion.component.html',
  styleUrls: ['./editar-alineacion.component.css']
})
export class EditarAlineacionComponent implements AfterViewInit {

  public jugadores: Array<Jugador>;
  public posiciones: Array<String>;
  public partido: Partido;
  public Id: number;
  public alineacion: Alineacion;

  constructor(private _location: Location,
    private router: Router,
    private route: ActivatedRoute,
    private partidoService: PartidoService) {
    this.route.params.subscribe(params => this.Id = params['idPartido'] );
    }

  ngAfterViewInit() {
    this.alineacion = new Alineacion();

    this.ActualizarFuentes();

    this.posiciones = this.partidoService.obtenerPosiciones();
  }

  private ActualizarFuentes() {
    this.partidoService.obtenerJugadores().subscribe(data => {
      this.jugadores = data;
    });

    this.partidoService.obtenerPartidoPorId(this.Id).subscribe(data => {
      this.partido = data;
    });
  }

  public EliminarAlineacion(Id: number): void {
    console.log('Eliminar id ' + Id);
    this.partidoService.EliminarAlineacion(Id).subscribe(data => this.ActualizarFuentes());
  }

  public EnviarAlineacion(): void {
    this.alineacion.Partido = this.Id;
    console.log('Guardar alineacion');
    this.partidoService.crearAlineacion(this.alineacion).subscribe(data => this.ActualizarFuentes());
  }

  regresar() {
    this._location.back(); // <-- regresar a la pagina previa al presionar cancelar
  }

}
