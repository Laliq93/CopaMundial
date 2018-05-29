import { Component, OnInit } from '@angular/core';

import { DatePipe } from '@angular/common';

import { ActivatedRoute } from '@angular/router';
import { Location } from '@angular/common';

import { JugadorService } from '../../services/jugador.service';

import { Jugador } from '../../models/jugador';

@Component({
  selector: 'app-jugador-detalle',
  templateUrl: './jugador-detalle.component.html',
  styleUrls: ['./jugador-detalle.component.css']
})
export class JugadorDetalleComponent implements OnInit {

  jugador: Jugador = new Jugador();

  temporal: string;

  id: number;

  constructor(
    private route: ActivatedRoute,
    private jugadorService: JugadorService,
    private location: Location,
    private datePipe: DatePipe
  ) {
    this.getJugador();
  }

  ngOnInit() {

    // this.jugador_temp = new Jugador();
    // this.loadJugador();
  }

  getJugador(): void {
    this.id = +this.route.snapshot.paramMap.get('id');
    console.log('id:' + this.id);
    if (this.id !== 0) {
      const env = this;
      this.jugadorService.getJugador(this.id)
        .subscribe(jugador => {
          env.jugador = jugador;

          // env.temporal = env.convertDateToString(env.jugador.FechaNacimiento);
        });
    }
  }

  convertDateToString(date: Date): string {
    // this.temporal = this.datePipe.transform(this.jugador_temp.fecha_nac.toISOString(), 'yyyy-MM-dd');
    // conversion a ISO y split
    const test = date.toISOString().split('T');
    return test[0];
    // const x = env.jugador.fecha_nac.toISOString().split('T');
  }

  goBack(): void {
    this.location.back();
  }

  saveChanges(): void {
    // const temp_date = this.temporal + 'T00:00:00Z';
    // const date: Date = new Date(Date.parse(this.temporal));
    // this.jugador.FechaNacimiento = date;

    if (this.id !== 0) {
      this.jugadorService.updateJugador(this.jugador)
        .subscribe(() => this.goBack());
    } else {
      this.jugadorService.addJugador(this.jugador)
        .subscribe(() => this.goBack());
    }

  }

}
