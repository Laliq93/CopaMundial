import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TeamComponent } from './client/team.component';
import { TeamAdminComponent } from './admin/team-admin.component';
import { CrearEquipoComponent } from './admin/crear-equipo/crear-equipo.component';
import { EditarEquipoComponent } from './admin/editar-equipo/editar-equipo.component';
import { InhabilitarEquipoComponent } from './admin/inhabilitar-equipo/inhabilitar-equipo.component';

@NgModule({
  imports: [CommonModule],
  declarations: [ 
  	TeamComponent,
  	TeamAdminComponent,
  	CrearEquipoComponent,
  	EditarEquipoComponent,
  	InhabilitarEquipoComponent
  ],
  providers: [],
  exports: [ 
  	TeamComponent,
  	TeamAdminComponent 
  ]
})

export class TeamModule {}