import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { LoggedInGuard } from '../guards/logged-in.guard'
import { NotLoggedInGuard } from '../guards/not-logged-in.guard'

import { Modulo01RoutingModule } from './modulo01-routing.module';
import { HomeComponent } from './components/home/home.component';
import { LoginComponent } from './components/login/login.component';
import { SigninComponent } from './components/signin/signin.component';
import { SignupComponent } from './components/signup/signup.component';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    Modulo01RoutingModule
  ],
  providers: [
    LoggedInGuard,
    NotLoggedInGuard
  ],
  declarations: [HomeComponent, LoginComponent, SigninComponent, SignupComponent]
})
export class Modulo01Module { }
