import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BetComponent } from './client/bet.component';
import { BetAdminComponent } from './admin/bet-admin.component';

@NgModule({
  imports: [CommonModule],
  declarations: [
  	BetComponent,
  	BetAdminComponent
  ],
  providers: [],
  exports: [ 
  	BetComponent,
  	BetAdminComponent
  ]
})

export class BetModule {}