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
import { RecoveryComponent } from './components/recovery/recovery.component';
import { ChangePasswordComponent } from './components/changePassword/changePassword.component';
import { BrowserModule } from '@angular/platform-browser';

@NgModule({
  imports: [
    CommonModule,
    BrowserModule,
    FormsModule,
    Modulo01RoutingModule
  ],
  providers: [
    LoggedInGuard,
    NotLoggedInGuard
  ],
  declarations: [HomeComponent, LoginComponent, SigninComponent, SignupComponent, RecoveryComponent, ChangePasswordComponent]
})
export class Modulo01Module { }