import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';


import { AchievementComponent } from './client/achievement.component';
import { AchievementAdminComponent } from './admin/achievement-admin.component';
import { AchievementGraphComponent } from './admin/achievement-graph/achievement-graph.component';
import { PercentageGraphComponent } from './admin/percentage-graph/percentage-graph.component';

@NgModule({
  imports: [
    CommonModule,
    BrowserModule, 
    BrowserAnimationsModule
   ],
  declarations: [
  	AchievementComponent,
  	AchievementAdminComponent,
    AchievementGraphComponent,
    PercentageGraphComponent
  ],
  providers: [],
  exports: [ 
  	AchievementComponent,
  	AchievementAdminComponent,
    AchievementGraphComponent,
    PercentageGraphComponent
  ]
})

export class AchievementModule {}