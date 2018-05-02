import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatchComponent } from './client/match.component';
import { MatchAdminComponent } from './admin/match-admin.component';
import { KnockoutPhaseComponent } from './client/knockout-phase/knockout-phase.component';
import { MatchDetailComponent } from './client/match-detail/match-detail.component';
@NgModule({
  imports: [CommonModule],
  declarations: [
  	MatchComponent,
    MatchAdminComponent,
    KnockoutPhaseComponent,
    MatchDetailComponent
  ],
  providers: [],
  exports: [
  	MatchComponent,
  	MatchAdminComponent
  ]
})

export class MatchModule {}
