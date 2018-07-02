import { Component, AfterViewInit } from '@angular/core';
import { RouterModule, Router, ActivatedRoute } from '@angular/router';
import { PartidoService } from '../../services/partido.service';
import { Partido } from '../../models/partido';
import { PartidoVer } from '../../models/partidoVer';
import { formatDate } from '@angular/common';

@Component({
  selector: 'app-admin-partido',
  templateUrl: './admin-partido.component.html',
  styleUrls: ['./admin-partido.component.css']
})
export class AdminPartidoComponent implements AfterViewInit {

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

  crearPartido(): void {
    this.router.navigate(['partidos/admin/crearPartido']);
  }

  editarAlineacion(Id) {
    this.router.navigate(['partidos/admin', 'editarAlineacion', Id]);
  }

  modificarPartido(Id): void {
    this.router.navigate(['partidos/admin', 'modificarPartido', Id ]);
  }

}
