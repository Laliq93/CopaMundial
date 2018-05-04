import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CityComponent } from './client/city.component';
import { CityAdminComponent } from './admin/city-admin.component';
import { ConsultarCiudadComponent } from './admin/consultar-ciudad/consultar-ciudad.component';
import { ModificarCiudadComponent } from './admin/modificar-ciudad/modificar-ciudad.component';
import { EliminarCiudadComponent } from './admin/eliminar-ciudad/eliminar-ciudad.component';
import { AgregarCiudadComponent } from './admin/agregar-ciudad/agregar-ciudad.component';

@NgModule({
  imports: [CommonModule],
  declarations: [
  	CityComponent,
  	CityAdminComponent,
  	ConsultarCiudadComponent,
  	ModificarCiudadComponent,
  	EliminarCiudadComponent,
  	AgregarCiudadComponent
  ],
  providers: [],
  exports: [ 
  	CityComponent,
  	CityAdminComponent
  ]
})

export class CityModule {}