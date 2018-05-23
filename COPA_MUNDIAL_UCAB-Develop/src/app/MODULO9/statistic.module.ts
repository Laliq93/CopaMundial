import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { StatisticComponent } from './client/statistic.component';
import { StatisticAdminComponent } from './admin/statistic-admin.component';
import { GroupComponent } from './group/group.component';
import { DatepickerComponent } from './datepicker/datepicker.component';
import { ContarClicksDirective } from './client/directiva.directive';
import { FormsModule } from '@angular/forms';
import { EstpartidosComponent } from './estpartidos/estpartidos.component';
//import {BsDatepickerModule} from 'ngx-bootstrap/datepicker';
//import {MatDatepickerModule} from '@angular/material/datepicker';

@NgModule({
  imports: [CommonModule,FormsModule],
  declarations: [
  	StatisticComponent,
    StatisticAdminComponent,
    DatepickerComponent,
    GroupComponent,
    ContarClicksDirective,
    EstpartidosComponent,
   

    
    
  ],
  providers: [],
  exports: [ 
  	StatisticComponent,
  	StatisticAdminComponent
  ]
})

export class StatisticModule {}