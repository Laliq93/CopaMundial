import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { DatePipe } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { Modulo05RoutingModule } from './modulo05-routing.module';
import { JugadoresComponent } from './components/jugadores/jugadores.component';
import { JugadorService } from './services/jugador.service';
import { Routes, RouterModule } from '@angular/router';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    HttpClientModule,
    Modulo05RoutingModule
  ],
  declarations: [
    JugadoresComponent
  ],
  providers: [
    DatePipe,
    JugadorService

  ]
})
export class Modulo05Module { }
