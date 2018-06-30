import { NgModule } from '@angular/core';
import { NotLoggedInGuard } from 'src/app/guards/not-logged-in.guard';
import { LoggedInGuard } from '../guards/logged-in.guard';
import { Routes, RouterModule } from '@angular/router';
import { VerPartidosComponent } from './components/ver-partidos/ver-partidos.component';
import { LogroEquipoComponent } from './components/logro-equipo/logro-equipo.component';
import { LogroCantidadComponent } from './components/logro-cantidad/logro-cantidad.component';

const routes: Routes = [
  
  //  { path: 'crearLogro', component: CrearLogroComponent, canActivate: [NotLoggedInGuard] },
    { path: '', component: VerPartidosComponent, canActivate: [NotLoggedInGuard] }/*,
    { path: 'logroPartido/:idPartido', component: LogroPartidoComponent, canActivate: [NotLoggedInGuard]}*/,
    { path: 'logroEquipo/:idPartido', component: LogroEquipoComponent, canActivate: [NotLoggedInGuard]},
    { path: 'logroCantidad/:idPartido', component: LogroCantidadComponent, canActivate: [NotLoggedInGuard]}/*,
    { path: 'logroJugador', component: LogroJugadorComponent, canActivate: [NotLoggedInGuard]},
    { path: 'logroVF', component: LogroVofComponent, canActivate: [NotLoggedInGuard]},*/
  ];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class Modulo07RoutingModule { }

