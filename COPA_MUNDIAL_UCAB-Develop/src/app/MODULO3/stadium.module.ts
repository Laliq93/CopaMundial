import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { StadiumComponent } from './client/stadium.component';
import { StadiumAdminComponent } from './admin/stadium-admin.component';

@NgModule({
  imports: [CommonModule],
  declarations: [
  	StadiumComponent,
  	StadiumAdminComponent
  ],
  providers: [],
  exports: [ 
  	StadiumComponent,
  	StadiumAdminComponent
  ]
})

export class StadiumModule {}