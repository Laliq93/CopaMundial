import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AchievementComponent } from './client/achievement.component';
import { AchievementAdminComponent } from './admin/achievement-admin.component';

@NgModule({
  imports: [CommonModule],
  declarations: [
  	AchievementComponent,
  	AchievementAdminComponent
  ],
  providers: [],
  exports: [ 
  	AchievementComponent,
  	AchievementAdminComponent
  ]
})

export class AchievementModule {}