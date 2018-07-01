import { NgModule } from '@angular/core';
import { NotLoggedInGuard } from 'src/app/guards/not-logged-in.guard';
import { LoggedInGuard } from '../guards/logged-in.guard';
import { Routes, RouterModule } from '@angular/router';
import { VerPartidosComponent } from './components/ver-partidos/ver-partidos.component';
import { LogroEquipoComponent } from './components/logro-equipo/logro-equipo.component';
import { LogroCantidadComponent } from './components/logro-cantidad/logro-cantidad.component';
import { LogroJugadorComponent } from './components/logro-jugador/logro-jugador.component';
import { LogroVFComponent } from './components/logro-vf/logro-vf.component';

const routes: Routes = [

    { path: '', component: VerPartidosComponent},
    { path: 'logroEquipo/:idPartido', component: LogroEquipoComponent},
    { path: 'logroCantidad/:idPartido', component: LogroCantidadComponent},
    { path: 'logroJugador/:idPartido', component: LogroJugadorComponent},
    { path: 'logroVF/:idPartido', component: LogroVFComponent}
  ];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class Modulo07RoutingModule { }

