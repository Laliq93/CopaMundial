import { Component, OnInit } from '@angular/core';

import { Jugador } from '../../models/jugador';

import { JugadorService } from '../../services/jugador.service';

@Component({
  selector: 'app-jugadores',
  templateUrl: './jugadores.component.html',
  styleUrls: ['./jugadores.component.css']
})
export class JugadoresComponent implements OnInit {
  title = 'Jugadores';

  esAdmin = true;

  jugadores: Jugador[];

  jugadorActual: Jugador = null;

  searchTerm = '';

  constructor(
    private jugadorService: JugadorService
  ) { }

  ngOnInit() {
    this.getJugadores();
  }

  getJugadores(): void {
    this.jugadorService.getJugadores().subscribe(jugadores => this.jugadores = jugadores);
  }

  search(): void {
    this.jugadorService.searchJugador(this.searchTerm).subscribe(data => {
      if (data.length > 0) {
        this.jugadores = data;
      }
    });
    this.searchTerm = '';
  }

  selectedJugador(jugador: Jugador): void {
    if (this.jugadorActual !== jugador) {
      this.jugadorActual = jugador;
    } else {
      this.jugadorActual = null;
    }
  }
}
