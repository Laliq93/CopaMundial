import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TeamComponent } from './client/team.component';
import { TeamAdminComponent } from './admin/team-admin.component';

@NgModule({
  imports: [CommonModule],
  declarations: [ 
  	TeamComponent,
  	TeamAdminComponent
  ],
  providers: [],
  exports: [ 
  	TeamComponent,
  	TeamAdminComponent 
  ]
})

export class TeamModule {}