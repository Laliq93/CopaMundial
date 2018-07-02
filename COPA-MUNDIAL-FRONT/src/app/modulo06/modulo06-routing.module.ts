import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LoggedInGuard } from '../guards/logged-in.guard';
import { NotLoggedInGuard } from '../guards/not-logged-in.guard';
import { AdminPartidoComponent } from './components/admin-partido/admin-partido.component';
import { ClienteDetallesComponent } from './components/cliente-detalles/cliente-detalles.component';
import { ClientePartidoComponent } from './components/cliente-partido/cliente-partido.component';
import { IsAdminGuard } from '../guards/is-admin.guard';
import { FormComponent } from './components/form/form.component';
import { CrearPartidoComponent } from './components/crear-partido/crear-partido.component';
import { ModificarPartidoComponent } from 'src/app/modulo06/components/modificar-partido/modificar-partido.component';
import { EditarAlineacionComponent } from './components/editar-alineacion/editar-alineacion.component';


const routes: Routes = [
  { path: 'admin/editarAlineacion/:idPartido', component: EditarAlineacionComponent, canActivate: [NotLoggedInGuard] },

  { path: '', component: ClientePartidoComponent, canActivate: [NotLoggedInGuard] },
  { path: 'listaPartidos', component: AdminPartidoComponent, canActivate: [NotLoggedInGuard] },
  { path: 'detallePartido/:idPartido', component: ClienteDetallesComponent, canActivate: [NotLoggedInGuard]},

  { path: 'admin', component: AdminPartidoComponent, canActivate: [NotLoggedInGuard] },
  { path: 'form', component: FormComponent },
  { path: 'admin/modificarPartido/:idPartido', component: ModificarPartidoComponent, canActivate: [NotLoggedInGuard] },
  { path: 'admin/crearPartido', component: CrearPartidoComponent, canActivate: [NotLoggedInGuard] },

];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})

export class Modulo06RoutingModule { }
