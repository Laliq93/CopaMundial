import { Component, AfterViewInit } from '@angular/core';
import { RouterModule, Router, ActivatedRoute } from '@angular/router';
import { Location } from '@angular/common';
import { Partido } from '../../models/partido';
import { PartidoService } from '../../services/partido.service';
import { Equipo } from '../../models/equipo';

@Component({
  selector: 'app-cliente-detalles',
  templateUrl: './cliente-detalles.component.html',
  styleUrls: ['./cliente-detalles.component.css']
})
export class ClienteDetallesComponent implements AfterViewInit {

  public Id: number;
  public partido: Partido;

  constructor(private route: ActivatedRoute,
    private router: Router,
    private location: Location,
    private partidoService: PartidoService) {
    this.route.params.subscribe(params => this.Id = params['idPartido'] );
  }


  ngAfterViewInit() {
    console.log(this.Id);
    this.partidoService.obtenerPartidoPorId(this.Id).subscribe(data => {
      this.partido = data;
      this.orderForView();
    });
  }

  private orderForView() {
    console.log(this.partido);
    this.partido.bandera1 = '../../../assets/banderas/' + (this.partido.Equipo1 as Equipo).Pais + '.png';
    this.partido.bandera2 = '../../../assets/banderas/' + (this.partido.Equipo2 as Equipo).Pais + '.png';
  }

  public goBack() {
    this.location.back();
  }

  faseGrupos(): void {
    this.router.navigate(['partidos']);
  }
}
