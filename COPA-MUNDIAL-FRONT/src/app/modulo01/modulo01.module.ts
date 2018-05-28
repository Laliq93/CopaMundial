import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { LoggedInGuard } from '../guards/logged-in.guard'
import { NotLoggedInGuard } from '../guards/not-logged-in.guard'

import { Modulo01RoutingModule } from './modulo01-routing.module';
import { HomeComponent } from './components/home/home.component';
import { LoginComponent } from './components/login/login.component';
import { SignupComponent } from './components/signup/signup.component';
import { SigninComponent } from './components/signin/signin.component';
import { HttpClientModule } from '@angular/common/http';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    HttpClientModule,
    Modulo01RoutingModule
  ],
  providers: [
    LoggedInGuard,
    NotLoggedInGuard
  ],
  declarations: [HomeComponent, LoginComponent, SignupComponent, SigninComponent]
})
export class Modulo01Module { }
