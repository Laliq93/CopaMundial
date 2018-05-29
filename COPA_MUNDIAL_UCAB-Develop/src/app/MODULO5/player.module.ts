import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PlayerComponent } from './client/player.component';
import { PlayerAdminComponent } from './admin/player-admin.component';

@NgModule({
  imports: [CommonModule],
  declarations: [
  	PlayerComponent,
  	PlayerAdminComponent
  ],
  providers: [],
  exports: [ 
  	PlayerComponent,
  	PlayerAdminComponent 
  ]
})

export class PlayerModule {}