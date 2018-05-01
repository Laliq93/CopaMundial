import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AppComponent } from './app.component'

import { HomeComponent } from './home/home.component'
import { AdminComponent } from './admin/admin.component'

//client
import { LoginComponent } from './MODULO1/client/login.component'
import { SigninComponent } from './MODULO1/client/signin.component'
import { SignupComponent } from './MODULO1/client/signup.component'
import { CityComponent } from './MODULO2/client/city.component'
import { StadiumComponent } from './MODULO3/client/stadium.component'
import { TeamComponent } from './MODULO4/client/team.component'
import { PlayerComponent } from './MODULO5/client/player.component'
import { MatchComponent } from './MODULO6/client/match.component'
import { AchievementComponent } from './MODULO7/client/achievement.component'
import { BetComponent } from './MODULO8/client/bet.component'
import { StatisticComponent } from './MODULO9/client/statistic.component'
import { UserPanelComponent } from './MODULO10/client/user-panel.component'

//admin
import { LoginAdminComponent } from './MODULO1/admin/login-admin.component'
import { CityAdminComponent } from './MODULO2/admin/city-admin.component'
import { StadiumAdminComponent } from './MODULO3/admin/stadium-admin.component'
import { TeamAdminComponent } from './MODULO4/admin/team-admin.component'
import { PlayerAdminComponent } from './MODULO5/admin/player-admin.component'
import { MatchAdminComponent } from './MODULO6/admin/match-admin.component'
import { AchievementAdminComponent } from './MODULO7/admin/achievement-admin.component'
import { BetAdminComponent } from './MODULO8/admin/bet-admin.component'
import { StatisticAdminComponent } from './MODULO9/admin/statistic-admin.component'
import { UserConfigAdminComponent } from './MODULO10/admin/user-config-admin.component'
import { StadiumDetailComponent } from './MODULO3/client/stadium-detail/stadium-detail.component';

const routes: Routes = [
  { path: '', redirectTo: 'login', pathMatch: 'full' },
  { path: 'login' ,  component:  LoginComponent },
  { path: 'signin' ,  component:  SigninComponent },
  { path: 'signup' ,  component:  SignupComponent },
  { path: 'home', component:  HomeComponent,
    children: [
      { path: 'city' ,  component: CityComponent },
      { path: 'stadium' , component: StadiumComponent},
      { path: 'stadium/detalle/:id' ,  component: StadiumDetailComponent },
      { path: 'team' , component: TeamComponent },
      { path: 'player' , component: PlayerComponent },
      { path: 'match' , component: MatchComponent },
      { path: 'achievement' , component: AchievementComponent },
      { path: 'bet' , component: BetComponent },
      { path: 'statistic' , component: StatisticComponent },
      { path: 'user-panel' , component: UserPanelComponent }
    ]
  },
  { path: 'admin', component:  AdminComponent,
    children: [
      { path: 'city' ,  component: CityAdminComponent },
      { path: 'stadium' , component: StadiumAdminComponent },
      { path: 'team' , component: TeamAdminComponent },
      { path: 'player' , component: PlayerAdminComponent },
      { path: 'match' , component: MatchAdminComponent },
      { path: 'achievement' , component: AchievementAdminComponent },
      { path: 'bet' , component: BetAdminComponent },
      { path: 'statistic' , component: StatisticAdminComponent },
      { path: 'user-panel' , component: UserConfigAdminComponent }
    ]
  },
];

@NgModule({
  imports: [ RouterModule.forRoot(routes) ],
  exports: [ RouterModule ]
})

export class AppRoutingModule {}