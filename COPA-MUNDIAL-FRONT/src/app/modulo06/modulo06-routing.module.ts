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
import { FormComponent } from './components/form/form.component';
import { CrearPartidoComponent } from './components/crear-partido/crear-partido.component';
import { ModificarPartidoComponent } from 'src/app/modulo06/components/modificar-partido/modificar-partido.component';


const routes: Routes = [
  { path: 'crearAlineacion', component: AdminCalineacionComponent, canActivate: [NotLoggedInGuard] }, // admin/alineacion

  { path: '', component: ClientePartidoComponent, canActivate: [NotLoggedInGuard] },
  { path: 'listaPartidos', component: AdminPartidoComponent, canActivate: [NotLoggedInGuard] },
  { path: 'detallePartido/:equipo1/:equipo2', component: ClienteDetallesComponent, canActivate: [NotLoggedInGuard]},

  { path: 'admin', component: AdminPartidoComponent, canActivate: [NotLoggedInGuard] },
  { path: 'form', component: FormComponent },
  { path: 'admin/modificarPartido/:equipo1/:equipo2', component: ModificarPartidoComponent, canActivate: [NotLoggedInGuard] },
  { path: 'admin/crearPartido', component: CrearPartidoComponent, canActivate: [NotLoggedInGuard] },

];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})

export class Modulo06RoutingModule { }
