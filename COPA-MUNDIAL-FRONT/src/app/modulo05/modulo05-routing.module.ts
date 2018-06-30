import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { JugadoresComponent } from './components/jugadores/jugadores.component';
import { JugadorDetalleComponent } from './components/jugador-detalle/jugador-detalle.component';


const routes: Routes = [
  { path: '', component: JugadoresComponent },
  { path: 'detalle', component: JugadorDetalleComponent },
  { path: 'detalle/:id', component: JugadorDetalleComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class Modulo05RoutingModule { }
