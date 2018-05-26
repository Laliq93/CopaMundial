import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { AppRoutingModule } from './app-routing.module';
<<<<<<< HEAD
import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
=======
import { NgForm, Form, FormGroup, AbstractControl, FormBuilder, FormControl, FormsModule, ReactiveFormsModule } from '@angular/forms';
import { UserService } from './MODULO1/client/user.service';


>>>>>>> Develop

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


import { HttpModule } from '@angular/http';
//angular pipes (directiva)

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    AdminComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    AppRoutingModule,
    AuthModule,
    CityModule,
    StadiumModule,
    TeamModule,
    MatchModule,
    PlayerModule,
    AchievementModule,
    BetModule,
    FormsModule,
    ReactiveFormsModule,
    StatisticModule,
    UserConfigModule,
    HttpClientModule
  ],
  providers: [
    ApiService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }