import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { StatisticComponent } from './client/statistic.component';
import { StatisticAdminComponent } from './admin/statistic-admin.component';

@NgModule({
  imports: [CommonModule],
  declarations: [
  	StatisticComponent,
  	StatisticAdminComponent
  ],
  providers: [],
  exports: [ 
  	StatisticComponent,
  	StatisticAdminComponent
  ]
})

export class StatisticModule {}