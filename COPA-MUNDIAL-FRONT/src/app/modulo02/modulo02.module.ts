import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {AgmCoreModule} from '@agm/core';
import { Modulo02RoutingModule } from './modulo02-routing.module';
import { FormsModule } from '@angular/Forms';
import { AgregarCiudadComponent } from './components/agregar-ciudad/agregar-ciudad.component';
import { EliminarCiudadComponent } from './components/eliminar-ciudad/eliminar-ciudad.component';
import { ConsultarCiudadComponent } from './components/consultar-ciudad/consultar-ciudad.component';
import { ModificarCiudadComponent } from './components/modificar-ciudad/modificar-ciudad.component';
@NgModule({
  imports: [
    CommonModule,
    Modulo02RoutingModule,
    FormsModule,
    AgmCoreModule.forRoot({

      apiKey:'AIzaSyCpRHl0N5ctxRWIGL-7TcqYSq-T9WMailY'

    })
  ],
  declarations: [AgregarCiudadComponent, EliminarCiudadComponent, ConsultarCiudadComponent, ModificarCiudadComponent]
 
})
export class Modulo02Module { }
