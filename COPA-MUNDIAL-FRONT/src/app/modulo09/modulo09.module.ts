import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { Modulo09RoutingModule } from './modulo09-routing.module';
import { EstgeneralComponent } from './estgeneral/estgeneral.component';
import { EstpartidoComponent } from './estpartido/estpartido.component';
import { EstjugadorComponent } from './estjugador/estjugador.component';
import { PredequipoComponent } from './predequipo/predequipo.component';

@NgModule({
  imports: [
    CommonModule,
    Modulo09RoutingModule
  ],
  declarations: [EstgeneralComponent, EstpartidoComponent, EstjugadorComponent, PredequipoComponent]
})
export class Modulo09Module { }
