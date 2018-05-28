import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {AgmCoreModule} from '@agm/core';
import { Modulo02RoutingModule } from './modulo02-routing.module';
//import { AgregarCiudadComponent } from './components/agregar-ciudad/agregar-ciudad.component';
//import { EditarCiudadComponent } from './components/editar-ciudad/editar-ciudad.component';
//import { ConsultarCiudadComponent } from './components/consultar-ciudad/consultar-ciudad.component';
//import { DetalleCiudadComponent } from './components/detalle-ciudad/detalle-ciudad.component';
import { FormsModule } from '@angular/Forms';
@NgModule({
  imports: [
    CommonModule,
    Modulo02RoutingModule,
    FormsModule,
    AgmCoreModule.forRoot({

      apiKey:'AIzaSyCpRHl0N5ctxRWIGL-7TcqYSq-T9WMailY'

    })
  ],
 // declarations: [AgregarCiudadComponent, EditarCiudadComponent, ConsultarCiudadComponent, DetalleCiudadComponent]
})
export class Modulo02Module { }
