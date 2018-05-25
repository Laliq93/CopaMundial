import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { Modulo02RoutingModule } from './modulo02-routing.module';
import { AgregarCiudadComponent } from './components/agregar-ciudad/agregar-ciudad.component';
import { EditarCiudadComponent } from './components/editar-ciudad/editar-ciudad.component';
import { ConsultarCiudadComponent } from './components/consultar-ciudad/consultar-ciudad.component';
import { DetalleCiudadComponent } from './components/detalle-ciudad/detalle-ciudad.component';

@NgModule({
  imports: [
    CommonModule,
    Modulo02RoutingModule
  ],
  declarations: [AgregarCiudadComponent, EditarCiudadComponent, ConsultarCiudadComponent, DetalleCiudadComponent]
})
export class Modulo02Module { }
