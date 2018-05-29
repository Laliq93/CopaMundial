import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { LoggedInGuard } from '../guards/logged-in.guard'
import { NotLoggedInGuard } from '../guards/not-logged-in.guard'

import { Modulo06RoutingModule } from './modulo06-routing.module';
import { ClientePartidoComponent } from './components/cliente-partido/cliente-partido.component';
import { ClienteDetallesComponent } from './components/cliente-detalles/cliente-detalles.component';
import { AdminPartidoComponent } from './components/admin-partido/admin-partido.component';
import { AdminCpartidoComponent } from './components/admin-cpartido/admin-cpartido.component';
import { AdminCalineacionComponent } from './components/admin-calineacion/admin-calineacion.component';
import { AdminMpartidoComponent } from './components/admin-mpartido/admin-mpartido.component';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    Modulo06RoutingModule
  ],
  providers: [
    LoggedInGuard,
    NotLoggedInGuard
  ],
  declarations: [ClientePartidoComponent, ClienteDetallesComponent, AdminPartidoComponent, AdminCpartidoComponent, AdminCalineacionComponent, AdminMpartidoComponent]
})
export class Modulo06Module { }

