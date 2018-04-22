import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { UserPanelComponent } from './client/user-panel.component';
import { UserConfigAdminComponent } from './admin/user-config-admin.component';

@NgModule({
  imports: [CommonModule],
  declarations: [
  	UserPanelComponent,
  	UserConfigAdminComponent
  ],
  providers: [],
  exports: [ 
  	UserPanelComponent,
  	UserConfigAdminComponent
  ]
})

export class UserConfigModule {}