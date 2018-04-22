import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CityComponent } from './client/city.component';
import { CityAdminComponent } from './admin/city-admin.component';

@NgModule({
  imports: [CommonModule],
  declarations: [
  	CityComponent,
  	CityAdminComponent
  ],
  providers: [],
  exports: [ 
  	CityComponent,
  	CityAdminComponent
  ]
})

export class CityModule {}