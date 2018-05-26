import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AppComponent } from './app.component';

import { HomeComponent } from './home/home.component';
import { AdminComponent } from './admin/admin.component';

//client
import { LoginComponent } from './MODULO1/client/login.component'
import { SigninComponent } from './MODULO1/client/signin.component'
import { SignupComponent } from './MODULO1/client/signup.component'
import { RecoveryComponent } from './MODULO1/client/recovery.component'
import { ChangePasswordComponent } from './MODULO1/client/changePassword.component'
import { CityComponent } from './MODULO2/client/city.component'
import { StadiumComponent } from './MODULO3/client/stadium.component'
import { TeamComponent } from './MODULO4/client/team.component'
import { PlayerComponent } from './MODULO5/client/player.component'
import { MatchComponent } from './MODULO6/client/match.component'
import { MatchDetailComponent } from './MODULO6/client/match-detail/match-detail.component'
import { AchievementComponent } from './MODULO7/client/achievement.component'
import { BetComponent } from './MODULO8/client/bet.component'
import { MybetsComponent } from './MODULO8/client/mybets/mybets.component'
import { StatisticComponent } from './MODULO9/client/statistic.component'
import { UserPanelComponent } from './MODULO10/client/user-panel.component'
import { UserConfigComponent} from './MODULO10/client/user-config.component'
import { UserSecurityComponent } from './MODULO10/client/user-security.component'


//admin
import { LoginAdminComponent } from './MODULO1/admin/login-admin.component'
import { CityAdminComponent } from './MODULO2/admin/city-admin.component'
import { ConsultarCiudadComponent } from './MODULO2/admin/consultar-ciudad/consultar-ciudad.component'
import { EliminarCiudadComponent } from './MODULO2/admin/eliminar-ciudad/eliminar-ciudad.component'
import { AgregarCiudadComponent } from './MODULO2/admin/agregar-ciudad/agregar-ciudad.component'
import { ModificarCiudadComponent } from './MODULO2/admin/modificar-ciudad/modificar-ciudad.component'
import { StadiumAdminComponent } from './MODULO3/admin/stadium-admin.component'
import { TeamAdminComponent } from './MODULO4/admin/team-admin.component'
import { PlayerAdminComponent } from './MODULO5/admin/player-admin.component'
import { MatchAdminComponent } from './MODULO6/admin/match-admin.component'
import { MatchLineUpCreateComponent } from './MODULO6/admin/match-line-up-create/match-line-up-create.component'
import { MatchAdminCreateComponent } from './MODULO6/admin/match-admin-create/match-admin-create.component'
import { MatchAdminUpdateComponent } from './MODULO6/admin/match-admin-update/match-admin-update.component'
import { AchievementAdminComponent } from './MODULO7/admin/achievement-admin.component'
import { BetAdminComponent } from './MODULO8/admin/bet-admin.component'
import { StatisticAdminComponent } from './MODULO9/admin/statistic-admin.component'
import { UserConfigAdminComponent } from './MODULO10/admin/user-config-admin.component'
import { StadiumDetailComponent } from './MODULO3/client/stadium-detail/stadium-detail.component'
import { CreateStadiumComponent } from './MODULO3/admin/create-stadium/create-stadium.component'
import { StadiumDetailAdminComponent } from './MODULO3/admin/stadium-detail-admin/stadium-detail-admin.component';

const routes: Routes = [
  { path: '', redirectTo: 'login', pathMatch: 'full' },
  { path: 'login' ,  component:  LoginComponent },
  { path: 'signin' ,  component:  SigninComponent },
  { path: 'signup' ,  component:  SignupComponent },
  { path: 'recovery' ,  component:  RecoveryComponent },
  { path: 'changePassword' ,  component:  ChangePasswordComponent },
  { path: 'home', component:  HomeComponent,

    children: [
      { path: 'city' ,  component: CityComponent },
      { path: 'stadium' , component: StadiumComponent},
      { path: 'stadium/detalle/:id' ,  component: StadiumDetailComponent },
      { path: 'team' , component: TeamComponent },
      { path: 'player' , component: PlayerComponent },
      { path: 'match' , component: MatchComponent },
      { path: 'match/Detalle/:id' , component: MatchDetailComponent },
      { path: 'achievement' , component: AchievementComponent },
      { path: 'bet' , component: BetComponent },
      { path: 'bet/mybets' , component: MybetsComponent },
      { path: 'statistic' , component: StatisticComponent },
      { path: 'user-panel' , component: UserPanelComponent },
      { path: 'user-config', component: UserConfigComponent },
      { path: 'user-security', component: UserSecurityComponent},
    ]
  },


  { path: 'admin', component:  AdminComponent,
    children: [
      { path: 'city' ,  component: CityAdminComponent  },
      { path: 'city/agregar', component:   AgregarCiudadComponent } ,
      { path: 'city/consultar', component:   ConsultarCiudadComponent } ,
      { path: 'city/eliminar', component:   EliminarCiudadComponent } ,
      { path: 'city/modificar', component:   ModificarCiudadComponent } ,
      { path: 'stadium' , component: StadiumAdminComponent },
      { path: 'stadium/detalle/:id' ,  component: StadiumDetailAdminComponent },
      { path: 'stadium/crear-estadio' ,  component: CreateStadiumComponent },
      { path: 'team' , component: TeamAdminComponent },
      { path: 'player' , component: PlayerAdminComponent },
      { path: 'match' , component: MatchAdminComponent },
      { path: 'match/lineup' , component: MatchLineUpCreateComponent},
      { path: 'match/create' , component: MatchAdminCreateComponent },
      { path: 'match/update' , component: MatchAdminUpdateComponent },
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
