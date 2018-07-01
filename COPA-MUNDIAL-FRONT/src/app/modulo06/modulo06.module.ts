import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { LoggedInGuard } from '../guards/logged-in.guard';
import { NotLoggedInGuard } from '../guards/not-logged-in.guard';
import { HttpClientModule } from '@angular/common/http';

import { Modulo06RoutingModule } from './modulo06-routing.module';
import { ClientePartidoComponent } from './components/cliente-partido/cliente-partido.component';
import { ClienteDetallesComponent } from './components/cliente-detalles/cliente-detalles.component';
import { AdminPartidoComponent } from './components/admin-partido/admin-partido.component';
import { FormComponent } from './components/form/form.component';
import { CrearPartidoComponent } from './components/crear-partido/crear-partido.component';
import { ModificarPartidoComponent } from './components/modificar-partido/modificar-partido.component';
import { VerAlineacionComponent } from './components/ver-alineacion/ver-alineacion.component';
import { EditarAlineacionComponent } from './components/editar-alineacion/editar-alineacion.component';
import { PartidoService } from './services/partido.service';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    HttpClientModule,
    Modulo06RoutingModule,
  ],
  providers: [
    LoggedInGuard,
    NotLoggedInGuard,
    PartidoService
  ],
  declarations: [
    ClientePartidoComponent,
    ClienteDetallesComponent,
    AdminPartidoComponent,
    FormComponent,
    CrearPartidoComponent,
    ModificarPartidoComponent,
    VerAlineacionComponent,
    EditarAlineacionComponent,
  ]
})
export class Modulo06Module { }


