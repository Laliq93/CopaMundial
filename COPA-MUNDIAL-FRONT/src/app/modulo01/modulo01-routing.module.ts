import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './components/home/home.component';
import { HomeAdminComponent } from './components/homeAdmin/homeAdmin.component';
import { LoggedInGuard } from '../guards/logged-in.guard';
import { NotLoggedInGuard } from '../guards/not-logged-in.guard';
import { LoginComponent } from './components/login/login.component';
import { SignupComponent } from './components/signup/signup.component';
import { SigninComponent } from './components/signin/signin.component';
import { RecoveryComponent } from './components/recovery/recovery.component';
import { ChangePasswordComponent } from './components/changePassword/changePassword.component';
import { IsAdminGuard } from '../guards/is-admin.guard';


const routes: Routes = [
  { path: '', component: HomeComponent, canActivate: [LoggedInGuard] },
  { path: 'admin', component: HomeAdminComponent, canActivate: [LoggedInGuard], canLoad: [IsAdminGuard] },
  { path: 'login', component: LoginComponent, canActivate: [NotLoggedInGuard] },
  { path: 'signup', component: SignupComponent, canActivate: [NotLoggedInGuard] },
  { path: 'signin', component: SigninComponent, canActivate: [NotLoggedInGuard] },
  { path: 'recovery', component: RecoveryComponent, canActivate: [NotLoggedInGuard] },
  { path: 'changePassword', component: ChangePasswordComponent, canActivate: [NotLoggedInGuard] }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class Modulo01RoutingModule { }
