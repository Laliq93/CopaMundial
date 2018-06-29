import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LoggedInGuard } from '../guards/logged-in.guard';
import { NotLoggedInGuard } from '../guards/not-logged-in.guard';

import { RegistrarApuestaComponent } from './components/registrar-apuesta/registrar-apuesta.component';
import { GestionarApuestaComponent } from './components/gestionar-apuesta/gestionar-apuesta.component';
import { VerApuestaComponent } from './components/ver-apuesta/ver-apuesta.component';
import { HistorialApuestaComponent } from './components/historial-apuesta/historial-apuesta.component';
import { AdminApuestaComponent } from './components/admin-apuesta/admin-apuesta.component';


const routes: Routes = [
  { path: '', component: RegistrarApuestaComponent },
  { path: 'gestionar', component: GestionarApuestaComponent },
  { path: 'mostrar/:idPartido', component: VerApuestaComponent },
  { path: 'historial', component: HistorialApuestaComponent },
  { path: 'adminapuesta', component: AdminApuestaComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class Modulo08RoutingModule { }
