import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { JugadoresComponent } from './components/jugadores/jugadores.component';

const routes: Routes = [
  { path: '', component: JugadoresComponent },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class Modulo05RoutingModule { }
