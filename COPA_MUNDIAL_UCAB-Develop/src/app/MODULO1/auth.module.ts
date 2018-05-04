import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LoginComponent } from './client/login.component';
import { SigninComponent } from './client/signin.component';
import { SignupComponent } from './client/signup.component';
import { RecoveryComponent } from './client/recovery.component';
import { LoginAdminComponent } from './admin/login-admin.component';

@NgModule({
  imports: [CommonModule],
  declarations: [
  	LoginComponent,
    SigninComponent,
    SignupComponent,
    RecoveryComponent,
  	LoginAdminComponent
  ],
  providers: [],
  exports: [ 
  	LoginComponent,
    SigninComponent,
    SignupComponent,
    RecoveryComponent,
	LoginAdminComponent
  ]
})

export class AuthModule {}