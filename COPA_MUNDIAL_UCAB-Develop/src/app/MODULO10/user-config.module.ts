import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { UserPanelComponent } from './client/user-panel.component';
import { UserConfigAdminComponent } from './admin/user-config-admin.component';
import { UserConfigComponent } from './client/user-config.component';
import { UserSecurityComponent } from './client/user-security.component';
import { FormsModule } from '@angular/forms';

@NgModule({
  imports: [CommonModule, FormsModule],
  declarations: [
  	UserPanelComponent,
    UserConfigAdminComponent,
    UserConfigComponent,
    UserSecurityComponent
  ],
  providers: [],
  exports: [ 
  	UserPanelComponent,
    UserConfigAdminComponent,
    UserConfigComponent,
    UserSecurityComponent
  ]
})

export class UserConfigModule {}