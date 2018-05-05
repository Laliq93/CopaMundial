import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AppRoutingModule } from './app-routing.module';

//modulos
import { AuthModule } from './MODULO1/auth.module';
import { CityModule } from './MODULO2/city.module';
import { StadiumModule } from './MODULO3/stadium.module';
import { TeamModule } from './MODULO4/team.module';
import { PlayerModule } from './MODULO5/player.module';
import { MatchModule } from './MODULO6/match.module';
import { AchievementModule } from './MODULO7/achievement.module';
import { BetModule } from './MODULO8/bet.module';
import { StatisticModule } from './MODULO9/statistic.module';
import { UserConfigModule } from './MODULO10/user-config.module';

//componentes
import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';
import { AdminComponent } from './admin/admin.component';


//servicios
import { ApiService } from './shared/api.service';



//angular pipes (directiva)

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    AdminComponent,
    
   
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    AuthModule,
    CityModule,
    StadiumModule,
    TeamModule,
    MatchModule,
    PlayerModule,
    AchievementModule,
    BetModule,
    StatisticModule,
    UserConfigModule
  ],
  providers: [
    ApiService
  ],
  bootstrap: [ AppComponent ]
})
export class AppModule { }