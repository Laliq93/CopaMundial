import { Component, OnInit } from '@angular/core';
import { Location } from '@angular/common';
import { Router, ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-editar-alineacion',
  templateUrl: './editar-alineacion.component.html',
  styleUrls: ['./editar-alineacion.component.css']
})
export class EditarAlineacionComponent implements OnInit {

  public listaJugadores = [
    {
      nombre: 'NIGMATULLIN',
      posicion: 'portero',
      numero: '1',
      estado: 'titular'
    },
    {
      nombre: 'KOVTUN',
      posicion: 'defensa',
      numero: '2',
      estado: 'titular'
    },
    {
      nombre: 'NIKIFOROV',
      posicion: 'defensa',
      numero: '3',
      estado: 'titular'
    },
    {
      nombre: 'SOLOMATIN',
      posicion: 'defensa',
      numero: '5',
      estado: 'titular'
    },
    {
      nombre: 'SEMSHOV',
      posicion: 'defensa',
      numero: '6',
      estado: 'titular'
    },
    {
      nombre: 'ONOPKO',
      posicion: 'medio',
      numero: '7',
      estado: 'titular'
    },
    {
      nombre: 'KARPIN',
      posicion: 'medio',
      numero: '8',
      estado: 'titular'
    },
    {
      nombre: 'TITOV',
      posicion: 'medio',
      numero: '9',
      estado: 'titular'
    },
    {
      nombre: 'BESCHASTNYKH',
      posicion: 'delantero',
      numero: '11',
      estado: 'titular'
    },
    {
      nombre: 'PIMENOV',
      posicion: 'delantero',
      numero: '19',
      estado: 'titular'
    },
    {
      nombre: 'IZMAYLOV',
      posicion: 'delantero',
      numero: '20',
      estado: 'titular'
    },
    {
      nombre: 'SMERTIN',
      posicion: 'portero',
      numero: '19',
      estado: 'suplente'
    },
    {
      nombre: 'MOSTOVOY',
      posicion: 'defensor',
      numero: '10',
      estado: 'suplente'
    },
    {
      nombre: 'CHERCHESOV',
      posicion: 'defensor',
      numero: '12',
      estado: 'suplente'
    },
    {
      nombre: 'DAEV',
      posicion: 'delantero',
      numero: '13',
      estado: 'suplente'
    },
    {
      nombre: 'CHIGAYNOV',
      posicion: 'delantero',
      numero: '14',
      estado: 'suplente'
    },
    {
      nombre: 'ALENICHEV',
      posicion: 'delantero',
      numero: '15',
      estado: 'suplente'
    }
  ];

  public equipo1: string;
  public equipo2: string;

  constructor(private _location: Location, private router: Router, private route: ActivatedRoute) { }

  ngOnInit() {
    this.equipo1 = null;
    this.equipo2 = null;

    this.route.params.subscribe( params => this.equipo1 = params['equipo1'] );
    this.route.params.subscribe( params => this.equipo2 = params['equipo2'] );
  }

  public agregar( jugador ) {
    let titulares = 0;
    this.listaJugadores.forEach(function (player) {
      if (player.estado === 'titular') {
        titulares++;
      }
    });

    if (titulares < 11) {
      jugador.estado = 'titular';
    } else {
      alert('Ya estan los once titulares!');
    }
  }

  public descartar( jugador ) {
    jugador.estado = 'suplente';
  }

  regresar() {
    this._location.back(); // <-- regresar a la pagina previa al presionar cancelar
  }

}
