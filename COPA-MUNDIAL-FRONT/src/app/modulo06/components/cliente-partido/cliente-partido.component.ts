import { Component, AfterViewInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { PartidoService } from '../../services/partido.service';
import { Partido } from '../../models/partido';
import { RouterModule, Router } from '@angular/router';

@Component({
  selector: 'app-cliente-partido',
  templateUrl: './cliente-partido.component.html',
  styleUrls: ['./cliente-partido.component.css']
})

export class ClientePartidoComponent implements AfterViewInit {

  public listMatches: Array<Partido>;

  constructor(private router: Router,
    private partidoService: PartidoService) { }

  ngAfterViewInit() {
    this.partidoService.obtenerPartidos().subscribe(data => {
      this.listMatches = data;
      this.orderForView();
    });
  }

  private orderForView() {
    console.log(this.listMatches);
    this.listMatches.sort((a, b) => new Date(a.FechaInicioPartido).getTime() - new Date(b.FechaInicioPartido).getTime());
    for (const match of Object.keys(this.listMatches)) {
      this.listMatches[match].bandera1 = '../../../assets/banderas/' + this.listMatches[match].Equipo1.Pais + '.png';
      this.listMatches[match].bandera2 = '../../../assets/banderas/' + this.listMatches[match].Equipo2.Pais + '.png';
    }
  }

  // muestra vista de detalle de equipos
  details(Id): void {
    this.router.navigate(['partidos', 'detallePartido', Id ]);
  }
}
