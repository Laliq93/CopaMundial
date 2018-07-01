import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-form',
  templateUrl: './form.component.html',
  styleUrls: ['./form.component.css']
})
export class FormComponent implements OnInit {

  public listaEstadios = [
    {
      nombre: 'Rostov Arena',
      ciudad: 'Rostov'
    },
    {
      nombre: 'Spartak Stadium',
      ciudad: 'Moscú'
    },
    {
      nombre: 'Luzhniki Stadium',
      ciudad: 'Moscú'
    },
    {
      nombre: 'Nizhny Novgorod Stadium',
      ciudad: 'Nizhny Novgorod'
    },
    {
      nombre: 'Samara Arena',
      ciudad: 'Samara'
    },
    {
      nombre: 'Kazan Arena',
      ciudad: 'Kazán'
    },
    {
      nombre: 'Saint Petersburg Stadium',
      ciudad: 'San Petersburgo'
    },
    {
      nombre: 'Mordovia Arena',
      ciudad: 'Saransk'
    },
    {
      nombre: 'Ekaterinburg Arena',
      ciudad: 'Ekaterinburgo'
    },
    {
      nombre: 'Kaliningrad Stadium',
      ciudad: 'Kaliningrado'
    },
    {
      nombre: 'Volgogrado Arena',
      ciudad: 'Volgogrado'
    },
    {
      nombre: 'Fisht Stadium',
      ciudad: 'Sochi'
    }
  ];
  public listaEquipos = [
    {
      nombre: 'España',
      iso: 'esp'
    },
    {
      nombre: 'Portugal',
      iso: 'por'
    },
    {
      nombre: 'Egipto',
      iso: 'egy'
    },
    {
      nombre: 'Uruguay',
      iso: 'uru'
    },
    {
      nombre: 'Marruecos',
      iso: 'mar'
    }, 
    {
      nombre: 'RI de Irán',
      iso: 'irn'
    }
  ];

  public equipo1: string;
  public equipo2: string;

  constructor(private router: Router, private route: ActivatedRoute) { }

  ngOnInit() {
    this.equipo1 = null;
    this.equipo2 = null;

    this.route.params.subscribe( params => this.equipo1 = params['equipo1'] );
    this.route.params.subscribe( params => this.equipo2 = params['equipo2'] );
  }

  matchList(): void {
    this.router.navigate(['partidos/listaPartidos']);
  }
 
  matchLineup(): void {
    this.router.navigate(['partidos/partidos']);
  }

  onSubnit(): void {
    this.router.navigate(['partidos/crearAlineacion']);
  }

}
