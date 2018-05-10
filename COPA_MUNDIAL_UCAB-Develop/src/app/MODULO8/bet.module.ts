import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BetComponent } from './client/bet.component';
import { BetAdminComponent } from './admin/bet-admin.component';
import { MybetsComponent } from './client/mybets/mybets.component';

@NgModule({
  imports: [CommonModule],
  declarations: [
  	BetComponent,
    BetAdminComponent,
    MybetsComponent
  ],
  providers: [],
  exports: [ 
  	BetComponent,
    BetAdminComponent,
    MybetsComponent
  ]
})

export class BetModule {}