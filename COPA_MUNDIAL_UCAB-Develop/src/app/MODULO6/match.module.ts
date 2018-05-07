import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatchComponent } from './client/match.component';
import { MatchAdminComponent } from './admin/match-admin.component';
import { KnockoutPhaseComponent } from './client/knockout-phase/knockout-phase.component';
import { MatchDetailComponent } from './client/match-detail/match-detail.component';
import { ChangeComponent } from './admin/change/change.component';
import { CreateComponent } from './admin/create/create.component';
@NgModule({
  imports: [CommonModule],
  declarations: [
  	MatchComponent,
    MatchAdminComponent,
    KnockoutPhaseComponent,
    MatchDetailComponent,
    ChangeComponent,
    CreateComponent
  ],
  providers: [],
  exports: [
  	MatchComponent,
  	MatchAdminComponent
  ]
})

export class MatchModule {}
