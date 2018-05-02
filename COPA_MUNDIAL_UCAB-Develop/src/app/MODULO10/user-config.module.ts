import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { UserPanelComponent } from './client/user-panel.component';
import { UserConfigAdminComponent } from './admin/user-config-admin.component';
import { UserConfigComponent } from './client/user-config.component';
import { UserSecurityComponent } from './client/user-security.component';
import { UserAccessibilityComponent } from './client/user-accessibility.component';

@NgModule({
  imports: [CommonModule],
  declarations: [
  	UserPanelComponent,
    UserConfigAdminComponent,
    UserConfigComponent,
    UserSecurityComponent,
    UserAccessibilityComponent
  ],
  providers: [],
  exports: [ 
  	UserPanelComponent,
    UserConfigAdminComponent,
    UserConfigComponent,
    UserSecurityComponent,
    UserAccessibilityComponent
  ]
})

export class UserConfigModule {}