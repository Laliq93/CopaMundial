import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { StadiumComponent } from './client/stadium.component';
import { StadiumAdminComponent } from './admin/stadium-admin.component';
import { StadiumDetailComponent } from './client/stadium-detail/stadium-detail.component';
import { CreateStadiumComponent } from './client/create-stadium/create-stadium.component';

@NgModule({
  imports: [CommonModule],
  declarations: [
  	StadiumComponent,
    StadiumAdminComponent,
    StadiumDetailComponent,
    CreateStadiumComponent
  ],
  providers: [],
  exports: [ 
  	StadiumComponent,
    StadiumAdminComponent,
    StadiumDetailComponent
  ]
})

export class StadiumModule {}