import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LoggedInGuard } from '../guards/logged-in.guard';
import { NotLoggedInGuard } from '../guards/not-logged-in.guard';
import { AdminCalineacionComponent } from './components/admin-calineacion/admin-calineacion.component';
import { AdminCpartidoComponent } from './components/admin-cpartido/admin-cpartido.component';
import { AdminMpartidoComponent } from './components/admin-mpartido/admin-mpartido.component';
import { AdminPartidoComponent } from './components/admin-partido/admin-partido.component';
import { ClienteDetallesComponent } from './components/cliente-detalles/cliente-detalles.component';
import { ClientePartidoComponent } from './components/cliente-partido/cliente-partido.component';
import { IsAdminGuard } from '../guards/is-admin.guard';


const routes: Routes = [ 
  
{ path: 'partidos', component: AdminCalineacionComponent, canActivate: [NotLoggedInGuard] },//admin/alineacion
{ path: 'crearPartido', component: AdminCpartidoComponent, canActivate: [IsAdminGuard] },
{ path: 'modificarPartido', component: AdminMpartidoComponent, canActivate: [NotLoggedInGuard] },
{ path: 'listaPartidos', component: AdminPartidoComponent, canActivate: [NotLoggedInGuard] },
{ path: 'listaPartidos', component: ClientePartidoComponent, canActivate: [LoggedInGuard] },
{ path: 'detallePartido', component: ClienteDetallesComponent, canActivate: [LoggedInGuard]}];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class Modulo06RoutingModule { }
