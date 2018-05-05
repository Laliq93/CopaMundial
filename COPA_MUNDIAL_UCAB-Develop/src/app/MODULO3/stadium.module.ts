import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { StadiumComponent } from './client/stadium.component';
import { StadiumAdminComponent } from './admin/stadium-admin.component';
import { StadiumDetailComponent } from './client/stadium-detail/stadium-detail.component';
import { StadiumDetailAdminComponent } from './admin/stadium-detail-admin/stadium-detail-admin.component';
import { CreateStadiumComponent } from './admin/create-stadium/create-stadium.component';

@NgModule({
  imports: [CommonModule],
  declarations: [
  	StadiumComponent,
    StadiumAdminComponent,
    StadiumDetailComponent,
    CreateStadiumComponent,
    StadiumDetailAdminComponent,
    StadiumAdminComponent
  ],
  providers: [],
  exports: [ 
  	StadiumComponent,
    StadiumAdminComponent,
    StadiumDetailComponent,
    StadiumDetailAdminComponent,
    StadiumAdminComponent
  ]
})

export class StadiumModule {}