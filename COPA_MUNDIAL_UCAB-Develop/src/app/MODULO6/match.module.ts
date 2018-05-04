import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatchComponent } from './client/match.component';
import { MatchAdminComponent } from './admin/match-admin.component';
import { MatchDetailComponent } from './client/match-detail/match-detail.component';
@NgModule({
  imports: [CommonModule],
  declarations: [
  	MatchComponent,
    MatchAdminComponent,
    MatchDetailComponent
  ],
  providers: [],
  exports: [
  	MatchComponent,
  	MatchAdminComponent
  ]
})

export class MatchModule {}
