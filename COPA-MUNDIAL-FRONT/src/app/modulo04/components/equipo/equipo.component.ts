import { Component, OnInit } from '@angular/core';

import { Router } from '@angular/router';
import { EquipoService } from '../../services/equipo.service';
import { Equipo } from '../../models/equipo';
import { LOCALE_ID } from '@angular/core';

@Component({
  selector: 'app-equipo',
  templateUrl: './equipo.component.html',
  styleUrls: ['./equipo.component.css']
})
export class EquipoComponent implements OnInit {
  public grupos: string[];
  public equipos: Equipo[] = null;
  public idioma = LOCALE_ID;

  constructor(private _equipoService: EquipoService, public router: Router) {}

  ngOnInit() {
    this.grupos = this._equipoService.obtenerGrupos();
    this._equipoService
      .obtenerEquipos()
      .subscribe(data => this.equipos = data);
  }

  public editarEquipo(idEquipo: String): void {
    this.router.navigate(['/equipos', 'editar', idEquipo]);
  }
}
