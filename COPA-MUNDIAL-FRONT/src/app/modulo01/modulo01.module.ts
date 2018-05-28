import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { LoggedInGuard } from '../guards/logged-in.guard'
import { NotLoggedInGuard } from '../guards/not-logged-in.guard'

import { Modulo01RoutingModule } from './modulo01-routing.module';
import { HomeComponent } from './components/home/home.component';
import { HomeAdminComponent } from './components/homeAdmin/homeAdmin.component';
import { LoginComponent } from './components/login/login.component';
import { SignupComponent } from './components/signup/signup.component';
import { SigninComponent } from './components/signin/signin.component';
import { RecoveryComponent } from './components/recovery/recovery.component';
import { ChangePasswordComponent } from './components/changePassword/changePassword.component';
import { HttpClientModule } from '@angular/common/http';
import { Routes, RouterModule } from '@angular/router';


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
  declarations: [HomeComponent, HomeAdminComponent, LoginComponent, SignupComponent, SigninComponent, RecoveryComponent, ChangePasswordComponent]
})
export class Modulo01Module { }
