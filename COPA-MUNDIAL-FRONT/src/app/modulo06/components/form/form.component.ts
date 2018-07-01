import { Component, AfterViewInit, Input } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { Estadio } from '../../models/estadio';
import { Equipo } from '../../models/equipo';
import { Partido } from '../../models/partido';
import { PartidoService } from '../../services/partido.service';

@Component({
  selector: 'app-form',
  templateUrl: './form.component.html',
  styleUrls: ['./form.component.css']
})
export class FormComponent implements AfterViewInit {

  @Input() public idPartido: number = null;
  public listaEstadios: Array<Estadio>;
  public listaEquipos: Array<Equipo>;
  public partido: Partido  = new Partido();

  public Id: number;

  constructor(private router: Router,
    private route: ActivatedRoute,
    private partidoService: PartidoService) {}

  ngAfterViewInit() {
    this.partidoService.obtenerEquipos().subscribe(data => this.listaEquipos = data);
    this.partidoService.obtenerEstadios().subscribe(data => this.listaEstadios = data);

    console.log(this.idPartido);
    if (this.idPartido != null) {
      this.partidoService.obtenerPartidoPorId(this.idPartido).subscribe(data => {
        this.partido = data;
        this.partido.Equipo1 = (this.partido.Equipo1 as Equipo).Id;
        this.partido.Equipo2 = (this.partido.Equipo2 as Equipo).Id;
        this.partido.Estadio = (this.partido.Estadio as Estadio).Id;
      });
    }
  }

  guardar(): void {
    if (this.idPartido != null) {
      this.partido.Id = this.idPartido;
      this.partidoService.actualizarPartido(this.partido).subscribe(data => this.router.navigate(['partidos/listaPartidos']));
    } else {
      this.partidoService.crearPartido(this.partido).subscribe(data => this.router.navigate(['partidos/listaPartidos']));
    }
  }

  matchList(): void {
    this.router.navigate(['partidos/listaPartidos']);
  }

  matchLineup(): void {
    this.router.navigate(['partidos/partidos']);
  }

}
