import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatchComponent } from './client/match.component';
import { MatchAdminComponent } from './admin/match-admin.component';
import { MatchDetailComponent } from './client/match-detail/match-detail.component';
import { MatchAdminUpdateComponent } from './admin/match-admin-update/match-admin-update.component';
import { MatchAdminCreateComponent } from './admin/match-admin-create/match-admin-create.component';
import { MatchLineUpCreateComponent } from './admin/match-line-up-create/match-line-up-create.component';
@NgModule({
  imports: [CommonModule],
  declarations: [
  	MatchComponent,
    MatchAdminComponent,
    MatchDetailComponent,
    MatchAdminUpdateComponent,
    MatchAdminCreateComponent,
    MatchLineUpCreateComponent,
  ],
  providers: [],
  exports: [
  	MatchComponent,
  	MatchAdminComponent
  ]
})

export class MatchModule {}
